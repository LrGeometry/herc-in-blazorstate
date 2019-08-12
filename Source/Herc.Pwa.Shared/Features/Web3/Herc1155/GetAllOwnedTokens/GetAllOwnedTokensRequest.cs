namespace Herc.Pwa.Shared.Features.Web3.Herc1155.GetAllOwnedTokens
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class GetAllOwnedTokensRequest : BaseRequest, IRequest<GetAllOwnedTokensResponse>
  {
    public const string Route = "api/getAllOwnedTokens";
  }
}