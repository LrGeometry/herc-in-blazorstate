namespace Herc.Pwa.Server.Features.Web3.NftCreator.MintNft
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Web3.NftCreator.MintNft;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(MintNftRequest.Route)]
  public class MintNftController : BaseController<MintNftRequest, MintNftResponse>
  {
    [HttpPost]
    public async Task<IActionResult> Post(MintNftRequest aRequest) => await Send(aRequest);
  }
}