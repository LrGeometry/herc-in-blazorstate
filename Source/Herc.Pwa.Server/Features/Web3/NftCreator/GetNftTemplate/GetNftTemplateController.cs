namespace Herc.Pwa.Server.Features.Web3.NftCreator.GetNftTemplate
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplate;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(GetNftTemplateRequest.Route)]
  public class GetNftByTypeServerFeaturesController : BaseController<GetNftTemplateRequest, GetNftTemplateResponse>
  {
    public async Task<IActionResult> Get(GetNftTemplateRequest aRequest) => await Send(aRequest);
  }
}