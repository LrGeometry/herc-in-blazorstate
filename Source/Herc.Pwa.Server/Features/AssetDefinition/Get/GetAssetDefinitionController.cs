namespace Herc.Pwa.Server.Features.AssetDefinition
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.AssetDefinition;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(GetAssetDefinitionRequest.Route)]
  public class GetAssetDefinitionController : BaseController<GetAssetDefinitionRequest, GetAssetDefinitionResponse>
  {
    [HttpGet]
    public async Task<IActionResult> Process(GetAssetDefinitionRequest aGetAssetDefinitionRequest) => await Send(aGetAssetDefinitionRequest);
  }
}