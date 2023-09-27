using commercetools.Sdk.Api.Models.Carts;
using commercetools.Sdk.Api.Models.Common;
using commercetools.Sdk.Api.Models.Orders;
using commercetools.Sdk.Api.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using Tts.Microservices.Products.Generated;

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
                LineItems = cart.LineItems?.AsSimpleModel(),
                Locale = cart.Locale,
                ShippingPrice = cart.ShippingInfo?.Price.AmountToDecimal(),
                ShippingMethod = cart.ShippingInfo?.ShippingMethod.Id,
                Store = cart.Store?.Key,
                TotalNet = cart.TaxedPrice?.TotalNet?.AmountToDecimal(),
                TotalGross = cart.TaxedPrice?.TotalGross?.AmountToDecimal(),
                TotalTax = cart.TaxedPrice?.TotalTax?.AmountToDecimal(),
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
                LineItems = order.LineItems?.AsSimpleModel(),
                Locale = order.Locale,
                ShippingPrice = order.ShippingInfo?.Price?.AmountToDecimal(),
                ShippingMethod = order.ShippingInfo?.ShippingMethod?.Id,
                Store = order.Store?.Key,
                TotalNet = order.TaxedPrice?.TotalNet?.AmountToDecimal(),
                TotalGross = order.TaxedPrice?.TotalGross?.AmountToDecimal(),
                TotalTax = order.TaxedPrice?.TotalTax?.AmountToDecimal(),
                TaxMode = order.TaxMode.Value?.ToString(),
                TotalPrice = order.TotalPrice?.AmountToDecimal(),
                CartId = order.Cart?.Id,
                PaymentState = order.PaymentState.ToString(),
                ShippingState = order.ShipmentState.ToString(),
                ShippingPriceTotalGross = order.TaxedShippingPrice?.TotalGross?.AmountToDecimal()
            };
        }

        public static IEnumerable<SimpleLineItem> AsSimpleModel(this IList<ILineItem> lineItems)
        {
            foreach (ILineItem li in lineItems)
            {
                li.Name.TryGetValue("DE", out string name);
                IPrice dePrice = li.Variant?.Prices?.FirstOrDefault(p => p.Country == "DE");
                yield return new()
                {
                    Id = li.Id,
                    ProductId = li.ProductId,
                    ProductNumber = li.ProductKey,
                    Name = name,
                    TypeId = li.ProductType.Id,
                    Price = new()
                    {
                        Value = dePrice?.Value?.AmountToDecimal(),
                        Discounted = dePrice?.Discounted?.Value?.AmountToDecimal()
                    },
                    ImageUrl = li.Variant?.Images?.FirstOrDefault()?.Url,
                    Availability = li.Variant?.Availability,
                    AddedAt = li.AddedAt,
                    LastModifiedAt = li.LastModifiedAt,
                    TaxedNetPrice = li.TaxedPrice?.TotalNet?.AmountToDecimal(),
                    TaxedGrossPrice = li.TaxedPrice?.TotalGross?.AmountToDecimal(),
                    Tax = li.TaxedPrice?.TotalTax?.AmountToDecimal()
                };
            }
        }

        public static SimpleAsset AsSimpleModel(this TtsSfAsset asset, string myFestoolId)
        {
            // Id, ProductCode__c, SalesNumber__c, Product2.Name, RegistrationDate__c, PurchaseDate, ManufactureDate, Status, Source__c from Asset where Contact.MyFestoolId__c
            return new()
            {
                Id = asset.Id,
                ProductCode = asset.ProductCode,
                SalesNumber = asset.SalesNumber__c,
                RegistrationDate = asset.RegistrationDate__c,
                PurchaseDate = asset.PurchaseDate,
                ManufactureDate = asset.ManufactureDate,
                Status = asset.Status,
                ProductName = asset.Product2?.Name,
                Source = asset.Source__c,
                MyFestoolId = myFestoolId
            };
        }
    }

    public class SimpleAsset
    {
        public string Id { get; internal set; }
        public string ProductCode { get; internal set; }
        public string ProductName { get; internal set; }
        public DateTime? PurchaseDate { get; internal set; }
        public string Status { get; internal set; }
        public string SalesNumber { get; internal set; }
        public DateTimeOffset? RegistrationDate { get; internal set; }
        public DateTime? ManufactureDate { get; internal set; }
        public string Source { get; internal set; }
        public string MyFestoolId { get; internal set; }
    }

    public class SimpleLineItem
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }
        public SimplePrice Price { get; set; }
        public string ImageUrl { get; set; }
        public IProductVariantAvailability Availability { get; set; }
        public DateTime? AddedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public decimal? TaxedNetPrice { get; set; }
        public decimal? TaxedGrossPrice { get; set; }
        public decimal? Tax { get; set; }
    }

    public class SimplePrice
    {
        public decimal? Value { get; set; }
        public decimal? Discounted { get; set; }
    }

    public class SimpleOrder
    {
        public string Id { get; set; }
        public string OrderNumber { get; set; }
        public string State { get; set; }
        public string CountryKey { get; set; }
        public string AnonymousId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public IEnumerable<SimpleLineItem> LineItems { get; set; }
        public string Locale { get; set; }
        public string Store { get; set; }
        public string TaxMode { get; set; }
        public decimal? TotalPrice { get; set; }
        public string CartId { get; set; }
        public string PaymentState { get; set; }
        public string ShippingState { get; set; }
        public decimal? ShippingPriceTotalGross { get; set; }
        public decimal? TotalNet { get; set; }
        public decimal? TotalGross { get; set; }
        public decimal? TotalTax { get; set; }
        public string ShippingMethod { get; set; }
        public decimal? ShippingPrice { get; set; }
    }

    public class SimpleCart
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string State { get; set; }
        public string CountryKey { get; set; }
        public string AnonymousId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public IEnumerable<SimpleLineItem> LineItems { get; set; }
        public string Locale { get; set; }
        public string Store { get; set; }
        public string TaxMode { get; set; }
        public long? TotalLineItemQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingPriceTotalGross { get; set; }
        public decimal? TotalNet { get; set; }
        public decimal? TotalGross { get; set; }
        public decimal? TotalTax { get; set; }
        public string ShippingMethod { get; set; }
        public decimal? ShippingPrice { get; set; }
    }
}
