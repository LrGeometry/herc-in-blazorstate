namespace Herc.Pwa.Server.Features.Web3.NftCreator.CreateTemplate
{
  using Herc.Pwa.Server.Features.Base;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(CreateTemplateRequest.Route)]
  public class AddNewTemplateServerFeaturesController : BaseController<CreateTemplateRequest, CreateTemplateResponse>
  {
    public async Task<IActionResult> Get(CreateTemplateRequest aRequest) => await Send(aRequest);
  }
}