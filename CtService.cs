using Festool.Ecommerce.CommerceTools.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleFunction
{
    public class CtService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public CtService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                CommerceToolsService commerceToolsService =
                    scope.ServiceProvider.GetRequiredService<CommerceToolsService>();

                var orders = await commerceToolsService.GetOrdersAsync();
                foreach (var order in orders.Results)
                {
                    await commerceToolsService.UpdateOrderAsync(order);
                }
            }
        }
    }
}