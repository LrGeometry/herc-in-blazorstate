namespace Herc.Pwa.Shared.Features.Web3.Herc1155.ViewMutableData
{
  using Herc.Pwa.Shared.Features.Base;
  using System;

  public class ViewMutableDataResponse : BaseResponse
  {
    public ViewMutableDataResponse() { }

    public ViewMutableDataResponse(Guid aRequestId) : base(aRequestId) { }
    
    public string MutableDataString { get; set; }
  }
}