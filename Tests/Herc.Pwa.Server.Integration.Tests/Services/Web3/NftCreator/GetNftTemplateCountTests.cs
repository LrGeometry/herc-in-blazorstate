namespace Herc.Pwa.Server.Integration.Tests.Services.Web3.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Services.Web3.NftCreator.GetNftTemplateCount;

  class GetNftTemplateCountTests
  {
    public GetNftTemplateCountTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }

    public async Task ShouldGetTotalNftTemplateTypes()
    {
      // Arrange
      var getNftTemplateCountRequest = new GetNftTemplateCountRequest();

      // Act
      GetNftTemplateCountResponse response = await Mediator.Send(getNftTemplateCountRequest);

      //Assert
      response.Count.ShouldBeGreaterThan(0U);

    }
  }
}
