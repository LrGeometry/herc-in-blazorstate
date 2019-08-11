namespace Herc.Pwa.Server.Services.Web3.NftCreator.MintNft
{
  using Nethereum.RPC.Eth.DTOs;

  public class MintNftResponse
  {
    public TransactionReceipt TransactionReceipt { get; set; }
    public MintNftEventDto MintNftEventDto { get; set; }
  }
}
