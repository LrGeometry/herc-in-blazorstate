namespace Herc.Pwa.Shared.Features.Web3.Herc1155.BalanceOf
{
  using Herc.Pwa.Shared.Features.Base;
  using System;

  public class BalanceResponse : BaseResponse
  {
    public BalanceResponse() { }

    public BalanceResponse(Guid aRequestId) : base(aRequestId) { }
    
    public int Balance { get; set; }
  }
}