namespace Herc.Pwa.Server.Features.Web3.Herc1155.GetAllOwnedTokens
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Web3.Herc1155.GetAllOwnedTokens;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(GetAllOwnedTokensRequest.Route)]
  public class GetAllOwnedTokensController : BaseController<GetAllOwnedTokensRequest, GetAllOwnedTokensResponse>
  {
    public async Task<IActionResult> Get(GetAllOwnedTokensRequest aRequest) => await Send(aRequest);
  }
}