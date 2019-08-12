namespace Herc.Pwa.Server.Features.Web3.Herc1155.BalanceOf
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Web3.Herc1155.BalanceOf;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(BalanceRequest.Route)]
  public class BalanceController : BaseController<BalanceRequest, BalanceResponse>
  {
    public async Task<IActionResult> Get(BalanceRequest aRequest) => await Send(aRequest);
  }
}