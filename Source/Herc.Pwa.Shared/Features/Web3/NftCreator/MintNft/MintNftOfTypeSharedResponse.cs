namespace Herc.Pwa.Shared.Features.Web3.NftCreator.MintNft
{
  using Herc.Pwa.Shared.Features.Base;
  using Nethereum.RPC.Eth.DTOs;
  using System;

  public class MintNftResponse : BaseResponse
  {
    public MintNftResponse() { }

    public MintNftResponse(Guid aRequestId) : base(aRequestId) { }

    public string GasUsed { get; set; }
    public TransactionReceipt MintingTransactionReceipt { get; set; }

    public int TokenId { get; set; }
    public string TransactionHash { get; set; }
  }
}