namespace Herc.Pwa.Server.Features.Web3.Herc1155.ViewTokenData
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Web3.Herc1155.ViewTokenData;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(ViewTokenDataRequest.Route)]
  public class ViewTokenDataServerFeaturesController : BaseController<ViewTokenDataRequest, ViewTokenDataResponse>
  {
    public async Task<IActionResult> Get(ViewTokenDataRequest aRequest) => await Send(aRequest);
  }
}