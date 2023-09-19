﻿using commercetools.Base.Client;
using commercetools.Sdk.Api;
using Festool.Ecommerce.CommerceTools.Services;
using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GoogleFunction.Startup))]
namespace GoogleFunction
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
        {
            services.UseCommercetoolsApi(context.Configuration);
            services.Configure<ClientConfiguration>(c => context.Configuration.Bind(DefaultClientNames.Api, c));
            services.AddScoped<CommerceToolsService>();

            base.ConfigureServices(context, services);
        }
    }
}
