using commercetools.Sdk.Api.Models.Carts;
using commercetools.Sdk.Api.Models.Common;
using commercetools.Sdk.Api.Models.Orders;
using commercetools.Sdk.Api.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

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
                LineItems = cart.LineItems.AsSimpleModel(),
                Locale = cart.Locale,
                ShippingPrice = cart.ShippingInfo?.Price.AmountToDecimal(),
                ShippingMethod = cart.ShippingInfo?.ShippingMethod.Id,
                Store = cart.Store.Key,
                TotalNet = cart.TaxedPrice.TotalNet.AmountToDecimal(),
                TotalGross = cart.TaxedPrice.TotalGross.AmountToDecimal(),
                TotalTax = cart.TaxedPrice.TotalTax.AmountToDecimal(),
                TaxMode = cart.TaxMode.Value?.ToString(),
                TotalLineItemQuantity = cart.TotalLineItemQuantity,
                TotalPrice = cart.TotalPrice.AmountToDecimal(),
                ShippingPriceTotalGross = cart.TaxedShippingPrice.TotalGross.AmountToDecimal()
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
                LineItems = order.LineItems.AsSimpleModel(),
                Locale = order.Locale,
                ShippingPrice = order.ShippingInfo?.Price.AmountToDecimal(),
                ShippingMethod = order.ShippingInfo?.ShippingMethod.Id,
                Store = order.Store.Key,
                TotalNet = order.TaxedPrice.TotalNet.AmountToDecimal(),
                TotalGross = order.TaxedPrice.TotalGross.AmountToDecimal(),
                TotalTax = order.TaxedPrice.TotalTax.AmountToDecimal(),
                TaxMode = order.TaxMode.Value?.ToString(),
                TotalPrice = order.TotalPrice.AmountToDecimal(),
                CartId = order.Cart.Id,
                PaymentState = order.PaymentState.ToString(),
                ShippingState = order.ShipmentState.ToString(),
                ShippingPriceTotalGross = order.TaxedShippingPrice.TotalGross.AmountToDecimal()
            };
        }

        public static IEnumerable<SimpleLineItem> AsSimpleModel(this IList<ILineItem> lineItems)
        {
            foreach (ILineItem li in lineItems)
            {
                yield return new()
                {
                    Id = li.Id,
                    ProductId = li.ProductId,
                    ProductNumber = li.ProductKey,
                    Name = li.Name["DE"],
                    TypeId = li.ProductType.Id,
                    Price = li.Variant.Prices.FirstOrDefault(p => p.Country == "DE"),
                    ImageUrl = li.Variant.Images.FirstOrDefault()?.Url,
                    Availability = li.Variant.Availability,
                    AddedAt = li.AddedAt,
                    LastModifiedAt = li.LastModifiedAt,
                    TaxedNetPrice = li.TaxedPrice.TotalNet.AmountToDecimal(),
                    TaxedGrossPrice = li.TaxedPrice.TotalGross.AmountToDecimal(),
                    Tax = li.TaxedPrice.TotalTax.AmountToDecimal(),
                };
            }
        }
    }

    public class SimpleLineItem
    {
        public string Id { get; internal set; }
        public string ProductId { get; internal set; }
        public string ProductNumber { get; internal set; }
        public string Name { get; internal set; }
        public string TypeId { get; internal set; }
        public IPrice Price { get; internal set; }
        public string ImageUrl { get; internal set; }
        public IProductVariantAvailability Availability { get; internal set; }
        public DateTime? AddedAt { get; internal set; }
        public DateTime? LastModifiedAt { get; internal set; }
        public decimal TaxedNetPrice { get; internal set; }
        public decimal TaxedGrossPrice { get; internal set; }
        public decimal Tax { get; internal set; }
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
        public IEnumerable<SimpleLineItem> LineItems { get; internal set; }
        public string Locale { get; internal set; }
        public string Store { get; internal set; }
        public string TaxMode { get; internal set; }
        public decimal TotalPrice { get; internal set; }
        public string CartId { get; internal set; }
        public string PaymentState { get; internal set; }
        public string ShippingState { get; internal set; }
        public decimal ShippingPriceTotalGross { get; internal set; }
        public decimal TotalNet { get; internal set; }
        public decimal TotalGross { get; internal set; }
        public decimal TotalTax { get; internal set; }
        public string ShippingMethod { get; internal set; }
        public decimal? ShippingPrice { get; internal set; }
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
        public IEnumerable<SimpleLineItem> LineItems { get; internal set; }
        public string Locale { get; internal set; }
        public string Store { get; internal set; }
        public string TaxMode { get; internal set; }
        public long? TotalLineItemQuantity { get; internal set; }
        public decimal TotalPrice { get; internal set; }
        public decimal ShippingPriceTotalGross { get; internal set; }
        public decimal TotalNet { get; internal set; }
        public decimal TotalGross { get; internal set; }
        public decimal TotalTax { get; internal set; }
        public string ShippingMethod { get; internal set; }
        public decimal? ShippingPrice { get; internal set; }
    }
}
