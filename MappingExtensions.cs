using commercetools.Sdk.Api.Models.Carts;
using commercetools.Sdk.Api.Models.Common;
using commercetools.Sdk.Api.Models.Orders;
using commercetools.Sdk.Api.Models.Stores;
using System;
using System.Collections.Generic;

namespace GoogleFunction
{
    public static class MappingExtensions
    {
        public static SimpleCart AsSimpleModel(this ICart cart)
        {
            return new()
            {
                Id = cart.Id,
                Key = cart.Key,
                State = cart.CartState.ToString(),
                CountryKey = cart.Country,
                AnonymousId = cart.AnonymousId,
                CustomerId = cart.CustomerId,
                CreatedAt = cart.CreatedAt,
                LastModifiedAt = cart.LastModifiedAt,
                LineItems = cart.LineItems,
                Locale = cart.Locale,
                ShippingInfo = cart.ShippingInfo,
                Store = cart.Store,
                TaxedPrice = cart.TaxedPrice,
                TaxMode = cart.TaxMode,
                TotalLineItemQuantity = cart.TotalLineItemQuantity,
                TotalPrice = cart.TotalPrice.AmountToDecimal(),
                TaxedShippingPrice = cart.TaxedShippingPrice
            };
        }

        public static SimpleOrder AsSimpleModel(this IOrder order)
        {
            return new()
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                State = order.OrderState.ToString(),
                CountryKey = order.Country,
                AnonymousId = order.AnonymousId,
                CustomerId = order.CustomerId,
                CreatedAt = order.CreatedAt,
                LastModifiedAt = order.LastModifiedAt,
                LineItems = order.LineItems,
                Locale = order.Locale,
                ShippingInfo = order.ShippingInfo,
                Store = order.Store,
                TaxedPrice = order.TaxedPrice,
                TaxMode = order.TaxMode,
                TotalPrice = order.TotalPrice.AmountToDecimal(),
                CartId = order.Cart.Id,
                PaymentState = order.PaymentState.ToString(),
                ShippingState = order.ShipmentState.ToString(),
                TaxedShippingPrice = order.TaxedShippingPrice
            };
        }
    }

    public class SimpleOrder
    {
        public string Id { get; internal set; }
        public string OrderNumber { get; internal set; }
        public string State { get; internal set; }
        public string CountryKey { get; internal set; }
        public string AnonymousId { get; internal set; }
        public string CustomerId { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public DateTime LastModifiedAt { get; internal set; }
        public IList<ILineItem> LineItems { get; internal set; }
        public string Locale { get; internal set; }
        public IShippingInfo ShippingInfo { get; internal set; }
        public IStoreKeyReference Store { get; internal set; }
        public ITaxedPrice TaxedPrice { get; internal set; }
        public ITaxMode TaxMode { get; internal set; }
        public decimal TotalPrice { get; internal set; }
        public ITaxedPrice TaxedShippingPrice { get; internal set; }
        public string CartId { get; internal set; }
        public string PaymentState { get; internal set; }
        public string ShippingState { get; internal set; }
    }

    public class SimpleCart
    {
        public string Id { get; internal set; }
        public string Key { get; internal set; }
        public string State { get; internal set; }
        public string CountryKey { get; internal set; }
        public string AnonymousId { get; internal set; }
        public string CustomerId { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public DateTime LastModifiedAt { get; internal set; }
        public IList<ILineItem> LineItems { get; internal set; }
        public string Locale { get; internal set; }
        public IShippingInfo ShippingInfo { get; internal set; }
        public IStoreKeyReference Store { get; internal set; }
        public ITaxedPrice TaxedPrice { get; internal set; }
        public ITaxMode TaxMode { get; internal set; }
        public long? TotalLineItemQuantity { get; internal set; }
        public decimal TotalPrice { get; internal set; }
        public ITaxedPrice TaxedShippingPrice { get; internal set; }
    }
}
