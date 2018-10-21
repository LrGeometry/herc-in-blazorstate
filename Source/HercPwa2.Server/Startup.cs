﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
namespace HercPwa2.Server
{
  using System.Linq;
  using System.Net.Mime;
  using System.Reflection;
  using MediatR;
  using Microsoft.AspNetCore.Blazor.Server;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.Extensions.DependencyInjection;
  using Newtonsoft.Json.Serialization;

  public class Startup
  {
    public void Configure(IApplicationBuilder aApplicationBuilder, IHostingEnvironment aHostingEnvironment)
    {
      aApplicationBuilder.UseStaticFiles();
      aApplicationBuilder.UseResponseCompression();

      if (aHostingEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
      }

      aApplicationBuilder.UseMvc(aRouteBuilder =>
      {
        aRouteBuilder.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
      });

      aApplicationBuilder.UseBlazor<Client.Program>();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddMvc()
        .AddJsonOptions(aMvcJsonOptions =>
        {
          aMvcJsonOptions.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });

      aServiceCollection.AddResponseCompression(aResponseCompressionOptions =>
      {
        aResponseCompressionOptions.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[]
          {
            MediaTypeNames.Application.Octet,
            WasmMediaTypeNames.Application.Wasm,
          });
      });
      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
      aServiceCollection.Scan(aTypeSourceSelector => aTypeSourceSelector
        .FromAssemblyOf<Startup>()
        .AddClasses()
        .AsSelf()
        .WithScopedLifetime());
    }
  }
}