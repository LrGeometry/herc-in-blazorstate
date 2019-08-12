namespace Herc.Pwa.Shared.Features.Web3.NftCreator.CreateTemplate
{
  using Herc.Pwa.Shared.Features.Base;
  using Nethereum.RPC.Eth.DTOs;

  public class CreateTemplateResponse : BaseResponse
  {
    public TransactionReceipt NewTemplateTransactionReceipt { get; set; }

  }
}
