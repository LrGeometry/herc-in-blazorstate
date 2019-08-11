namespace Herc.Pwa.Server.Features.Web3.NftCreator.GetNftTemplateCount
{
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplateCount;

  [Route(GetNftTemplateCountRequest.Route)]
  public class GetNftTemplateCountController : BaseController<GetNftTemplateCountRequest, GetNftTemplateCountResponse>
  {
    public async Task<IActionResult> Get(GetNftTemplateCountRequest aRequest) => await Send(aRequest);
  }
}
