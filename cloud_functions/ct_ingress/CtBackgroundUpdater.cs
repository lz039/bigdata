using commercetools.Sdk.Api.Models.Orders;
using Festool.Ecommerce.CommerceTools.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleFunction
{
    public class CtBackgroundUpdater : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public CtBackgroundUpdater(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                CommerceToolsService commerceToolsService =
                    scope.ServiceProvider.GetRequiredService<CommerceToolsService>();

                await foreach (IList<IOrder> orders in commerceToolsService.GetOrdersAsync())
                {
                    try
                    {
                        await commerceToolsService.UpdateOrderAsync(orders);
                    }
                    catch (Exception)
                    {
                        // skip
                    }
                }
            }
        }
    }
}