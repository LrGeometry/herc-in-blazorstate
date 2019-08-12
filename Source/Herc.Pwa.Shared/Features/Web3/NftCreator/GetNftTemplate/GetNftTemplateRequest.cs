namespace Herc.Pwa.Shared.Features.Web3.NftCreator.GetNftTemplate
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;
  
  public class GetNftTemplateRequest : BaseRequest, IRequest<GetNftTemplateResponse>
  {
    public const string Route = "api/getNftTemplate";

    public static string RouteFactory(int aId) => $"api/getNftTemplate?NftType={aId}";
    public uint NftTemplateId { get; set; }
  }

}