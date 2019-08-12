namespace Herc.Pwa.Server.Features.Web3.Herc1155.GetAllOwnedTokens
{
  using Herc.Pwa.Shared.Features.Web3.Herc1155.GetAllOwnedTokens;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.Herc1155.GetAllOwnedTokens;

  public class GetAllOwnedTokensHandler : IRequestHandler<GetAllOwnedTokensRequest, GetAllOwnedTokensResponse>
  {
    public GetAllOwnedTokensHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; set; }

    public async Task<GetAllOwnedTokensResponse> Handle
    (
      GetAllOwnedTokensRequest aGetAllOwnedTokensRequest,
      CancellationToken aCancellationToken
    )
    {
      var getAllOwnedTokensServiceRequest = new Services.GetAllOwnedTokensServiceRequest();

      Services.GetAllOwnedTokensServiceResponse response = await Mediator.Send(getAllOwnedTokensServiceRequest);

      return new GetAllOwnedTokensResponse()
      {
        TokenIdList = response.TokenIdList
      };
    }
  }
}