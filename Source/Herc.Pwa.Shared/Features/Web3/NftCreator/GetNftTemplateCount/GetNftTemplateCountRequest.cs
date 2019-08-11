namespace Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplateCount
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class GetNftTemplateCountRequest : BaseRequest, IRequest<GetNftTemplateCountResponse>
  {
    public const string Route = "api/GetNftTemplateCount";
  }
}