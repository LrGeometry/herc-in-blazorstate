namespace Herc.Pwa.Server.Features.Web3.Herc1155.ViewTokenData
{
  using Herc.Pwa.Shared.Features.Web3.Herc1155.ViewTokenData;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.Herc1155.ViewTokenData;

  public class ViewTokenDataServerFeaturesHandler : IRequestHandler<ViewTokenDataRequest, ViewTokenDataResponse>
  {
    public ViewTokenDataServerFeaturesHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; set; }

    public async Task<ViewTokenDataResponse> Handle
        (
          ViewTokenDataRequest aViewTokenDataRequest,
          CancellationToken aCancellationToken
        )
    {
      Services.ViewTokenDataServiceResponse response = await Mediator.Send
      (
        new Services.ViewTokenDataServiceRequest
        {
          ViewTokenId = aViewTokenDataRequest.TokenIdToGet
        }
      );

      return new ViewTokenDataResponse(new System.Guid())
      {
        TokenDataString = response.TokenDataString,
      };
    }
  }
}