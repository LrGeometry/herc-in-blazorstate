namespace Herc.Pwa.Server.Features.Web3.NftCreator.GetNftTemplateCount
{
  using Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplateCount;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.NftCreator.GetNftTemplateCount;

  public class GetNftTemplateCountHandler : IRequestHandler<GetNftTemplateCountRequest, GetNftTemplateCountResponse>
  {
    public GetNftTemplateCountHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; set; }

    public async Task<GetNftTemplateCountResponse> Handle
    (
      GetNftTemplateCountRequest aGetNftTemplateCountRequest,
      CancellationToken aCancellationToken
    )
    {
      Services.GetNftTemplateCountResponse response = await Mediator.Send(new Services.GetNftTemplateCountRequest());

      return new GetNftTemplateCountResponse
      {
        Count = response.Count
      };
    }
  }
}