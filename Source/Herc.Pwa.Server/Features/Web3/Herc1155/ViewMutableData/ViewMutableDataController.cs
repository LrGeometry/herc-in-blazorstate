namespace Herc.Pwa.Server.Features.Web3.Herc1155.ViewMutableData
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Web3.Herc1155.ViewMutableData;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(ViewMutableDataRequest.Route)]
  public class ViewMutableDataController : BaseController<ViewMutableDataRequest, ViewMutableDataResponse>
  {
    public async Task<IActionResult> Get(ViewMutableDataRequest aRequest) => await Send(aRequest);
  }
}