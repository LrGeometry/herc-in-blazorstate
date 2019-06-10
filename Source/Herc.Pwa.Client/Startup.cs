namespace Herc.Pwa.Client
{
  using Blazor.Extensions.Logging;
  using BlazorState;
  using BlazorState.Services;
  using FluentValidation;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Client.Components.Shared;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Util;
  using BlazorHostedCSharp.Client.Features.ClientLoader;
  using MediatR;
  using Microsoft.Extensions.Logging;

  public class Startup
  {
    public void Configure(IComponentsApplicationBuilder aComponentsApplicationBuilder) =>
      aComponentsApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      if (new BlazorHostingLocation().IsClientSide)
      {
        aServiceCollection.AddLogging(aLoggingBuilder => aLoggingBuilder
            .AddBrowserConsole()
            .SetMinimumLevel(LogLevel.Trace));
      };
	    aServiceCollection.AddSingleton<ColorPalette>();
	    aServiceCollection.AddSingleton<AmountConverter>();
	    aServiceCollection.AddSingleton<AddressUtil>();
	    aServiceCollection.AddScoped(typeof(IValidator<SendAction>), typeof(SendValidator));
      aServiceCollection.AddBlazorState();
      aServiceCollection.AddScoped<ClientLoader>();
      aServiceCollection.AddScoped<IClientLoaderConfiguration, ClientLoaderConfiguration>();
    }
  }
}