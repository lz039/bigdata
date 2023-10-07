using commercetools.Base.Client;
using commercetools.Sdk.Api.Client.RequestBuilders.Orders;
using commercetools.Sdk.Api.Client.RequestBuilders.Projects;
using commercetools.Sdk.Api.Extensions;
using commercetools.Sdk.Api.Models.Carts;
using commercetools.Sdk.Api.Models.Customers;
using commercetools.Sdk.Api.Models.Inventories;
using commercetools.Sdk.Api.Models.Orders;
using commercetools.Sdk.Api.Models.Products;
using commercetools.Sdk.Api.Models.ShoppingLists;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festool.Ecommerce.CommerceTools.Services;

public class CommerceToolsService
{
    private readonly ByProjectKeyRequestBuilder _ctClient;

    public CommerceToolsService(
        IClient ctClient,
        IOptions<ClientConfiguration> configuration)
    {
        _ctClient = ctClient.WithApi(configuration.Value.ProjectKey);
    }

    public Task<ICart> GetCartByIdAsync(Guid cartId)
    {
        var request = _ctClient
            .Carts()
            .WithId(cartId.ToString())
            .Get();

        return request.ExecuteAsync();
    }

    public Task<IOrder> GetOrderByIdAsync(Guid orderId)
    {
        var request = _ctClient
            .Orders()
            .WithId(orderId.ToString())
            .Get();

        return request.ExecuteAsync();
    }

    public Task<IProduct> GetProductById(Guid productId)
    {
        var request = _ctClient
            .Products()
            .WithId(productId.ToString())
            .Get();

        return request.ExecuteAsync();
    }

    public Task<IInventoryEntry> GetInventoryByIdAsync(Guid inventoryId)
    {
        var request = _ctClient
            .Inventory()
            .WithId(inventoryId.ToString())
            .Get();

        return request.ExecuteAsync();
    }

    public Task<IShoppingList> GetShoppingListByIdAsync(Guid shoppingListId)
    {
        var request = _ctClient
            .ShoppingLists()
            .WithId(shoppingListId.ToString())
            .Get();

        return request.ExecuteAsync();
    }

    public Task<ICustomer> GetCustomerByIdAsync(string customerId)
    {
        var request = _ctClient
            .Customers()
            .WithId(customerId)
            .Get();

        return request.ExecuteAsync();
    }

    public async IAsyncEnumerable<IList<IOrder>> GetOrdersAsync()
    {
        string lastId = null;
        bool goOn = true;
        while (goOn)
        {
            IOrderPagedQueryResponse response;
            if (lastId == null)
            {
                response = await _ctClient.Orders().Get().WithLimit(100).WithWithTotal(false).WithSort("id asc").ExecuteAsync();
            }
            else
            {
                response = await _ctClient.Orders().Get().WithLimit(100).WithWithTotal(false).WithSort("id asc").WithWhere($"id > \"{ lastId }\"").ExecuteAsync();
            }

            IList<IOrder> results = response.Results;
            goOn = results.Count == 100;
            lastId = results.LastOrDefault()?.Id;
            yield return results;
        }
    }

    public async Task UpdateOrderAsync(IList<IOrder> orders)
    {
        List<ByProjectKeyOrdersByIDPost> changeRequests = new();
        Parallel.ForEach(orders, order =>
        {
            changeRequests.Add(_ctClient
                .Orders()
                .WithId(order.Id)
                .Post(
                    new OrderUpdate()
                    {
                        Version = order.Version,
                        Actions = new List<IOrderUpdateAction>
                        {
                            new OrderChangeOrderStateAction
                            {
                                OrderState = order.OrderState
                            }
                        }
                    }));
        });

        List<Task<IOrder>> tasks = new();
        foreach (IEnumerable<ByProjectKeyOrdersByIDPost> requests in changeRequests.Chunk(50))
        {
            if (!requests.Any()) continue;
            tasks.AddRange(requests.Select(r => r?.ExecuteAsync()));
        }

        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception)
        {
        }
    }
}
