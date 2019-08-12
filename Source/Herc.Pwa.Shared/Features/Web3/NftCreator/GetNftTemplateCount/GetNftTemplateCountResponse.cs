namespace Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplateCount
{
  using System;
  using Herc.Pwa.Shared.Features.Base;

  public class GetNftTemplateCountResponse : BaseResponse
  {
    public GetNftTemplateCountResponse() { }

    public GetNftTemplateCountResponse(Guid aRequestId) : base(aRequestId) { }

    public uint Count { get; set; }
  }
}