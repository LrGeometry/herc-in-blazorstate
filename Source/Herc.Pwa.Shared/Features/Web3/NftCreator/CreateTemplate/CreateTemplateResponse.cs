namespace Herc.Pwa.Shared.Features.Web3.NftCreator.CreateTemplate
{
  using Herc.Pwa.Shared.Features.Base;
  using Nethereum.RPC.Eth.DTOs;
  using System;

  public class CreateTemplateResponse : BaseResponse
  {
    public CreateTemplateResponse() { }

    public CreateTemplateResponse(Guid aRequestId) : base(aRequestId) { }

    public TransactionReceipt NewTemplateTransactionReceipt { get; set; }
  }
}