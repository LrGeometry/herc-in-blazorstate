namespace Herc.Pwa.Server.Features.Application.Get
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Application;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(GetApplicationRequest.Route)]
  public class GetApplicationController : BaseController<GetApplicationRequest, GetApplicationResponse>
  {
    [HttpPost]
    public async Task<IActionResult> Post(GetApplicationRequest aRequest) => await Send(aRequest);
  }
}