namespace Herc.Pwa.Server.Features.Web3.NftCreator.MintNft
{
  using Herc.Pwa.Shared.Features.Web3.NftCreator.MintNft;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.NftCreator.MintNft;

  public class MintNftHandler : IRequestHandler<MintNftRequest, MintNftResponse>
  {
    IMediator Mediator { get; set; }

    public MintNftHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<MintNftResponse> Handle
    (
      MintNftRequest aMintNftOfTypeSharedRequest,
      CancellationToken aCancellationToken
    )
    {
      var aMintNftRequest = new Services.MintNftRequest {
        Type = aMintNftOfTypeSharedRequest.MintNftId,
        ImmutableDataString = aMintNftOfTypeSharedRequest.ImmutableDataString,
        MutableDataString = aMintNftOfTypeSharedRequest.MutableDataString

      };

      Services.MintNftResponse response = await Mediator.Send(aMintNftRequest);

      return new MintNftResponse
      {
        TransactionHash = response.TransactionReceipt.TransactionHash,
        TokenId = (int)response.MintNftEventDto.Id,
      };
    }
  }
}