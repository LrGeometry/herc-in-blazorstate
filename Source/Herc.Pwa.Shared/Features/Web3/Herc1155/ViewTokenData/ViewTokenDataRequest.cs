namespace Herc.Pwa.Shared.Features.Web3.Herc1155.ViewTokenData
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class ViewTokenDataRequest : BaseRequest, IRequest<ViewTokenDataResponse>
  {
    public const string Route = "api/viewTokenData";

    public uint TokenId { get; set; }

    public static string RouteFactory(int aId) => $"api/viewTokenData?TokenId={aId}";
  }
}