namespace Herc.Pwa.Shared.Features.Web3.NftCreator.MintNft
{
  using Herc.Pwa.Shared.Features.Base;
  using Nethereum.RPC.Eth.DTOs;

  public class MintNftResponse : BaseResponse
  {
    public TransactionReceipt MintingTransactionReceipt { get; set; }

    public int TokenId { get; set; }
    public string TransactionHash { get; set; }

    public string GasUsed { get; set; }
  }
}