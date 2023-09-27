using CloudNative.CloudEvents;
using commercetools.Sdk.Api.Models.Customers;
using Festool.Ecommerce.CommerceTools.Services;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Functions.Framework;
using Google.Cloud.Storage.V1;
using Google.Events.Protobuf.Cloud.PubSub.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tts.Microservices.Products.Generated;

namespace GoogleFunction;

/// <summary>
/// A function that can be triggered in responses to changes in Google Cloud Storage.
/// The type argument (StorageObjectData in this case) determines how the event payload is deserialized.
/// The function must be deployed so that the trigger matches the expected payload type. (For example,
/// deploying a function expecting a StorageObject payload will not work for a trigger that provides
/// a FirestoreEvent.)
/// </summary>
public class Function : ICloudEventFunction<MessagePublishedData>
{
    private readonly CommerceToolsService _commerceToolsCartService;
    private readonly SalesforceClient _salesforceClient;

    public Function(CommerceToolsService commerceToolsCartService, SalesforceClient salesforceClient)
    {
        _commerceToolsCartService = commerceToolsCartService;
        _salesforceClient = salesforceClient;
    }

    /// <summary>
    /// Logic for your function goes here. Note that a CloudEvent function just consumes an event;
    /// it doesn't provide any response.
    /// </summary>
    /// <param name="cloudEvent">The CloudEvent your function should consume.</param>
    /// <param name="data">The deserialized data within the CloudEvent.</param>
    /// <param name="cancellationToken">A cancellation token that is notified if the request is aborted.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task HandleAsync(CloudEvent cloudEvent, MessagePublishedData data, CancellationToken cancellationToken)
    {
        // {"notificationType":"ResourceUpdated","projectKey":"festool-prod","resource":{"typeId":"order","id":"fa209b2a-10e6-4376-ab09-47fbf2f951c2"},"resourceUserProvidedIdentifiers":{"orderNumber":"34488460"},"version":2,"oldVersion":1,"modifiedAt":"2023-09-09T10:22:37.396Z"}
        string textEventData = data.Message?.TextData;
        Console.WriteLine("Storage object information: " + data + ", " + textEventData);

        try
        {
            CtEvent ctEvent = JsonConvert.DeserializeObject<CtEvent>(textEventData);
            switch (ctEvent.Resource.TypeId)
            {
                case "cart":
                    var cart = await _commerceToolsCartService.GetCartByIdAsync(Guid.Parse(ctEvent.Resource.Id));
                    Console.WriteLine("CartId: " + cart?.Id);
                    await UploadObject(cart.Id, "cart", new[] { cart.AsSimpleModel() });
                    break;
                case "order":
                    var order = await _commerceToolsCartService.GetOrderByIdAsync(Guid.Parse(ctEvent.Resource.Id));
                    Console.WriteLine("OrderNumber: " + order?.OrderNumber);
                    await UploadObject(order.Id, "order", new[] { order.AsSimpleModel() });
                    if (ctEvent.NotificationType == nameof(NotificationTypes.ResourceCreated) && order.CustomerId != null)
                    {
                        ICustomer ctCustomer = await _commerceToolsCartService.GetCustomerByIdAsync(order.CustomerId);
                        if (ctCustomer is not null)
                        {
                            List<TtsSfAsset> assets = await _salesforceClient.QueryAsync<TtsSfAsset>($"SELECT Id, ProductCode__c, SalesNumber__c, Product2.Name, RegistrationDate__c, PurchaseDate, ManufactureDate, Status, Source__c from Asset where Contact.MyFestoolId__c = '{ctCustomer.Key}'", false);
                            if (assets?.Any() == true)
                            {
                                await UploadObject(ctCustomer.Key, "assets", assets.Select(a => a.AsSimpleModel(ctCustomer.Key)));
                            }
                        }
                    }
                    break;
                case "inventory-entry":
                    var inventory = await _commerceToolsCartService.GetInventoryByIdAsync(Guid.Parse(ctEvent.Resource.Id));
                    Console.WriteLine("Inventory: " + inventory?.Sku + " - " + inventory?.AvailableQuantity);
                    await UploadObject(inventory.Id, "inventory", new[] { inventory });
                    break;
                case "product":
                    var product = await _commerceToolsCartService.GetProductById(Guid.Parse(ctEvent.Resource.Id));
                    Console.WriteLine("Product: " + product?.Id);
                    await UploadObject(product.Id, "product", new[] { product });
                    break;
                case "shopping-list":
                    var shoppingList = await _commerceToolsCartService.GetShoppingListByIdAsync(Guid.Parse(ctEvent.Resource.Id));
                    Console.WriteLine("ShoppingList: " + shoppingList?.Id);
                    await UploadObject(shoppingList.Id, "shoppinglist", new[] { shoppingList });
                    break;
                default:
                    Console.WriteLine("Unhandeled typeId: " + ctEvent.Resource.TypeId);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing message: " + ex.Message);
        }
    }

    private static async Task UploadObject<T>(string id, string type, IEnumerable<T> data)
    {
        StorageClient client = StorageClient.Create();

        // Create a bucket with a globally unique name
        string bucketName = $"lz-{type}";
        try
        {
            Bucket bucket = await client.CreateBucketAsync("lz-bigdata", bucketName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating bucket {bucketName}: {ex.Message}");
        }

        // Upload some files
        try
        {
            object dataToUpload;
            using MemoryStream ms = new();
            if (data.Count() == 1)
            {
                dataToUpload = data.First();
            }
            else
            {
                dataToUpload = data;
            }

            //ParquetSchema parquet = await ParquetSerializer.SerializeAsync(data, file);
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dataToUpload));
            await client.UploadObjectAsync(bucketName, $"{id}.json", "application/json", new MemoryStream(bytes));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error serializing data: " + ex.Message);
        }
    }

    public enum NotificationTypes
    {
        ResourceCreated,
        ResourceUpdated,
        ResourceDeleted
    }
}
