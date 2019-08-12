namespace Herc.Pwa.Shared.Features.Web3.Herc1155.GetAllOwnedTokens
{
  using Herc.Pwa.Shared.Features.Base;
  using System;
  using System.Collections.Generic;

  public class GetAllOwnedTokensResponse : BaseResponse
  {
    public GetAllOwnedTokensResponse() { }

    public GetAllOwnedTokensResponse(Guid aRequestId) : base(aRequestId) { }

    public List<uint> TokenIdList { get; set; }
  }
}