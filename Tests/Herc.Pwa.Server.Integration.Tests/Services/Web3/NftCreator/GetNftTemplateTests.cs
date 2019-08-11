namespace Herc.Pwa.Server.Integration.Tests.Services.Web3.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Services.Web3.NftCreator.GetNftTemplate;

  class GetNftTemplateTests
  {
    public GetNftTemplateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }

    public async Task ShouldGetNft()
    {
      // Arrange
      var getNftRequest = new GetNftTemplateRequest { NftId = 4 };

      // Act
      GetNftTemplateResponse response = await Mediator.Send(getNftRequest);

      //Assert
      response.Name.ShouldNotBeNullOrWhiteSpace();
      response.Symbol.ShouldNotBeNullOrWhiteSpace();

    }
  }
}
