namespace Herc.Pwa.Server
{
  using AutoMapper;
  using Herc.Pwa.Server.Configuration;
  using Herc.Pwa.Server.Data;
  using Herc.Pwa.Server.Services.Web3;
  using MediatR;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using System.Linq;
  using System.Reflection;

  //using Shared.Features.Conversion;
  //using Server.Services.CryptoCompare.SingleSymbolPrice;
  //using Server.Services.CryptoCompare;

  public class Startup
  {
    public Startup(IConfiguration aconfiguration)
    {
      Configuration = aconfiguration;
    }

    public IConfiguration Configuration { get; }

    public void Configure
        (
      IApplicationBuilder aApplicationBuilder,
      IWebHostEnvironment aWebHostEnvironment
    )
    {

      // unsure if below line is needed or not
      aApplicationBuilder.UseHttpsRedirection();

      aApplicationBuilder.UseResponseCompression();

      if (aWebHostEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
        aApplicationBuilder.UseBlazorDebugging();
      }

      aApplicationBuilder.UseRouting();
      aApplicationBuilder.UseEndpoints
      (
        aEndpointRouteBuilder =>
        {
          aEndpointRouteBuilder.MapControllers(); // We use explicit attribute routing so dont need MapDefaultControllerRoute
          aEndpointRouteBuilder.MapBlazorHub();
          aEndpointRouteBuilder.MapFallbackToPage("/_Host");
        }
      );
      aApplicationBuilder.UseClientSideBlazorFiles<Client.Startup>();
    }

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      EthereumSettings ethereumSettings = Configuration.GetSection(nameof(EthereumSettings)).Get<EthereumSettings>();
      aServiceCollection.AddSingleton(ethereumSettings);
      //   aServiceCollection.AddCors(aCorsOptions =>
      //   {
      //     aCorsOptions.AddPolicy("any",
      //         aCorsPolicyBuilder => aCorsPolicyBuilder
      //         .AllowAnyOrigin()
      //         .AllowAnyMethod()
      //         .AllowAnyHeader()
      //         .AllowCredentials());
      //});
      aServiceCollection.AddRazorPages();

      var assemblies = new Assembly[] { typeof(Startup).Assembly };
      aServiceCollection.AddAutoMapper(assemblies);

      aServiceCollection
        .AddServerSideBlazor()
        .AddHubOptions(aHubOptions => aHubOptions.MaximumReceiveMessageSize = 102400000);

      string connectionString = Configuration.GetConnectionString(nameof(HercPwaDbContext));
      aServiceCollection.AddDbContext<HercPwaDbContext>
      (
        options => options.UseSqlServer(connectionString)
      );

      aServiceCollection.AddMvc();

      aServiceCollection.AddResponseCompression
      (
        aResponseCompressionOptions =>
          aResponseCompressionOptions.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat
          (
            new[] { "application/octet-stream" }
          )
      );

      //aServiceCollection.AddSingleton<HttpClient>();
      // TODO: when FluentValidation updated for dotnet core 3 we can use AddFluentValidation and it will scan for validators.
      // Until then we register them manually.
      //aServiceCollection.AddScoped<IValidator<ConversionRequest>, ConversionRequestValidator>();
      //aServiceCollection.AddScoped<IValidator<PriceRequest>, PriceRequestValidator>();
      //aServiceCollection.AddScoped<IValidator<SingleSymbolPriceRequest>, SingleSymbolPriceRequestValidator>();
      //aServiceCollection.AddScoped<IValidator<>, >();

      new Client.Startup().ConfigureServices(aServiceCollection);

      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
      aServiceCollection.AddSingleton<Web3ContractManager>();

      //aServiceCollection.Scan
      //(
      //  aTypeSourceSelector => aTypeSourceSelector
      //    .FromAssemblyOf<Startup>()
      //    .AddClasses()
      //    .AsSelf()
      //    .WithScopedLifetime()
      //);
    }
  }
}