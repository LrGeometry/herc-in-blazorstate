namespace BlazorState.Integration.Tests.Infrastructure
{
  using BlazorState;
  using FluentValidation;
  using Herc.Pwa.Client;
  using Herc.Pwa.Client.Features.Application;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using Herc.Pwa.Client.Integration.Tests.Infrastructure;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Util;
  using System;
  using System.Reflection;
  using System.Text.Json;

  /// <summary>
  /// A known starting state(baseline) for all tests.
  /// And Common set of functions
  /// </summary>
  public class TestFixture//: IMediatorFixture, IStoreFixture, IServiceProviderFixture
  {
    public TestFixture(BlazorStateTestServer aBlazorStateTestServer)
    {
      BlazorStateTestServer = aBlazorStateTestServer;
      WebAssemblyHostBuilder = BlazorWebAssemblyHost.CreateDefaultBuilder()
          .ConfigureServices(ConfigureServices);
    }

    private BlazorStateTestServer BlazorStateTestServer { get; }

    /// <summary>
    /// This is the ServiceProvider that will be used by the Client
    /// </summary>
    public IServiceProvider ServiceProvider => WebAssemblyHostBuilder.Build().Services;

    public IWebAssemblyHostBuilder WebAssemblyHostBuilder { get; }

    /// <summary>
    /// Special configuration for Testing with the Test Server
    /// </summary>
    /// <param name="aServiceCollection"></param>
    private void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddSingleton<AmountConverter>();
      aServiceCollection.AddSingleton(BlazorStateTestServer.CreateClient());
      aServiceCollection.AddBlazorState
      (
        aOptions => aOptions.Assemblies =
        new Assembly[] { typeof(Startup).GetTypeInfo().Assembly }
      );

      aServiceCollection.AddSingleton
      (
        new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }
      );

      aServiceCollection.AddSingleton<AddressUtil>();
      aServiceCollection.AddScoped(typeof(IValidator<SendAction>), typeof(SendValidator));

      // Add States
      aServiceCollection.AddTransient<ApplicationState>();
      aServiceCollection.AddTransient<EdgeState>();
      aServiceCollection.AddTransient<EdgeAccountState>();
      aServiceCollection.AddTransient<EdgeCurrencyWalletsState>();
    }
  }
}