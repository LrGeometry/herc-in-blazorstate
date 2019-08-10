namespace Herc.Pwa.Server.Features.AssetDefinition
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.AssetDefinition;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(CreateAssetDefinitionRequest.Route)]
  public class AssetDefinitionController : BaseController<CreateAssetDefinitionRequest, CreateAssetDefinitionResponse>
  {
    [HttpPost]
    public async Task<IActionResult> Post(CreateAssetDefinitionRequest aRequest) => await Send(aRequest);
  }
}