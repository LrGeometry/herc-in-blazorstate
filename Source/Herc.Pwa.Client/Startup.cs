﻿namespace Herc.Pwa.Client
{
  using Herc.Pwa.Client.Features.Application;
  using BlazorState;
  using FluentValidation;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Client.Components.Shared;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using MediatR;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using System.Reflection;
  using System.Text.Json.Serialization;
  using BlazorHostedCSharp.Client.Features.ClientLoader;

  public class Startup
  {
    public void Configure(IComponentsApplicationBuilder aComponentsApplicationBuilder) =>
      aComponentsApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddBlazorState
      (
        (aOptions) => aOptions.Assemblies =
          new Assembly[] 
          {
            typeof(Startup).GetTypeInfo().Assembly,
          }
      );
	    aServiceCollection.AddSingleton<ColorPalette>();
	    aServiceCollection.AddSingleton<AmountConverter>();
      	aServiceCollection.AddSingleton
      (
        new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }
      );

	  aServiceCollection.AddScoped(typeof(IValidator<SendAction>), typeof(SendValidator));
      //aServiceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventStreamBehavior<,>));
      aServiceCollection.AddScoped<ClientLoader>();
      aServiceCollection.AddScoped<IClientLoaderConfiguration, ClientLoaderConfiguration>();
      
      aServiceCollection.AddTransient<ApplicationState>();
      //aServiceCollection.AddTransient<EventStreamState>();
    }
  }
}