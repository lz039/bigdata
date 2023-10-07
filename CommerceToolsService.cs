using commercetools.Base.Client;
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

    internal Task<IOrderPagedQueryResponse> GetOrdersAsync()
    {
        var request = _ctClient
            .Orders()
            .Get();

        return request.ExecuteAsync();
    }

    internal async Task UpdateOrderAsync(IOrder order)
    {
        var request = _ctClient
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
                });

        try
        {
            await request.ExecuteAsync();
        }
        catch (Exception ex)
        {
        }

    }
}
