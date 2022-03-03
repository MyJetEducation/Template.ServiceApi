﻿using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyJetWallet.Sdk.Service;
using Prometheus;
using Service.AssetsDictionaryApi.Modules;
using Service.Core.Client.Constants;
using Service.Web;
using SimpleTrading.ServiceStatusReporterConnector;

namespace Service.AssetsDictionaryApi
{
    public class Startup
    {
        private const string DocumentName = "assetsdictionaryapi";
        private const string ApiName = "AssetsDictionaryApi";

        public void ConfigureServices(IServiceCollection services)
        {
            services.BindCodeFirstGrpc();
            services.AddHostedService<ApplicationLifetimeManager>();
            services.AddMyTelemetry(Configuration.TelemetryPrefix, Program.Settings.ZipkinUrl);
            services.SetupSwaggerDocumentation(DocumentName, ApiName);
            services.ConfigurateHeaders();
            services.AddControllers();
            services.ConfigureAuthentication();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseForwardedHeaders();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseMetricServer();
            app.BindServicesTree(Assembly.GetExecutingAssembly());
            app.BindIsAlive();
            app.UseOpenApi();
            app.UseAuthentication();
            app.UseAuthorization();
            app.SetupSwagger(DocumentName, ApiName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => await context.Response.WriteAsync("API endpoint"));
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<SettingsModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
