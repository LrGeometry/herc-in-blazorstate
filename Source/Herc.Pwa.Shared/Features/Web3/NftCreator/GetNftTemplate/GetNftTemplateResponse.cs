namespace Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplate
{
  using Herc.Pwa.Shared.Features.Base;
  using System;

  public class GetNftTemplateResponse : BaseResponse
  {
    public GetNftTemplateResponse() { }
    public GetNftTemplateResponse(Guid aRequestId)
    {
      RequestId = aRequestId;
    }
    public NftTemplateDto NftTemplate { get; set; }
  }
}