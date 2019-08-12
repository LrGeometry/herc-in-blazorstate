namespace Herc.Pwa.Shared.Features.Web3.NftCreator.MintNft
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class MintNftRequest : BaseRequest, IRequest<MintNftResponse>
  {
    public const string Route = "api/mintNft";

    public int MintNftId { get; set; }
    public string ImmutableDataString { get; set; }
    public string MutableDataString { get; set; }
  }

}
