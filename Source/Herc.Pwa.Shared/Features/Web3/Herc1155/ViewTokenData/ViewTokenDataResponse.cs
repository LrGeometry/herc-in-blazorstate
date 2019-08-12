namespace Herc.Pwa.Shared.Features.Web3.Herc1155.ViewTokenData
{
  using Herc.Pwa.Shared.Features.Base;
  using System;

  public class ViewTokenDataResponse : BaseResponse
  {
    public ViewTokenDataResponse() { }

    public ViewTokenDataResponse(Guid aRequestId) : base(aRequestId) { }

    public string TokenDataString { get; set; }
    // Token Type will determine what object to use to deserialize the data
    //public uint TokenNftType { get; set; }
  }
}