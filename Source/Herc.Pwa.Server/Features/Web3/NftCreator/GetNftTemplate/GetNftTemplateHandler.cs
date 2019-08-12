namespace Herc.Pwa.Server.Features.Web3.NftCreator.GetNftTemplate
{
  using Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplate;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.NftCreator.GetNftTemplate;

  public class GetNftTemplateHandler : IRequestHandler<GetNftTemplateRequest, GetNftTemplateResponse>
  {
    IMediator Mediator { get; set; }

    System.Guid guid { get; set; }
    public GetNftTemplateHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<GetNftTemplateResponse> Handle
    (
      GetNftTemplateRequest aGetNftTemplateRequest,
      CancellationToken aCancellationToken
    )
    {
      var aNftRequest = new Services.GetNftTemplateRequest { NftTemplateId = aGetNftTemplateRequest.NftTemplateId };

      Services.GetNftTemplateResponse response = await Mediator.Send(aNftRequest);

      return new GetNftTemplateResponse(aGetNftTemplateRequest.Id)
      {
        NftTemplate = new NftTemplateDto {
          AttachedTokens = response.AttachedTokens,
          MintLimit = response.MintLimit,
          Name = response.Name,
          Symbol = response.Symbol,
        }
      };
      
    }
  }
}