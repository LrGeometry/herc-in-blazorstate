namespace Herc.Pwa.Server.Integration.Tests.Features.Web3.NftCreator
{
  using Herc.Pwa.Server.Integration.Tests;
  using Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplateCount;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;

  internal class GetNftTemplateCountTests
  {
    public GetNftTemplateCountTests(TestFixture aTestFixture)
    {
      Mediator = aTestFixture.ServiceProvider.GetService<IMediator>();
    }

    private IMediator Mediator { get; }

    public async Task GetNftTemplateCountShouldBeAccurates()
    {
      var getNftTemplateCountRequest = new GetNftTemplateCountRequest();

      GetNftTemplateCountResponse response = await Mediator.Send(getNftTemplateCountRequest);

      response.Count.ShouldBeGreaterThan(2U);
    }
  }
}