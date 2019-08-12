namespace Herc.Pwa.Server.Features.Web3.Herc1155.ViewMutableData
{
  using Herc.Pwa.Shared.Features.Web3.Herc1155.ViewMutableData;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.Herc1155.ViewMutableData;

  public class ViewMutableDataHandler : IRequestHandler<ViewMutableDataRequest, ViewMutableDataResponse>
  {
    private readonly IMediator Mediator;

    public ViewMutableDataHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<ViewMutableDataResponse> Handle
    (
      ViewMutableDataRequest aViewMutableDataRequest,
      CancellationToken aCancellationToken
    )
    {
      Services.ViewMutableDataServiceResponse response = await Mediator.Send
      (
        new Services.ViewMutableDataServiceRequest
        {
          ViewTokenId = aViewMutableDataRequest.TokenId
        }
      );

      return new ViewMutableDataResponse(new System.Guid())
      {
        MutableDataString = response.MutableDataString
      };
    }
  }
}