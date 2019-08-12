namespace Herc.Pwa.Shared.Features.Web3.Herc1155.ViewMutableData
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class ViewMutableDataRequest : BaseRequest, IRequest<ViewMutableDataResponse>
  {
    public const string Route = "api/viewMutableData";

    public uint TokenId { get; set; }

    public static string RouteFactory(uint aId) => $"api/viewMutableData?TokenId={aId}";
  }
}