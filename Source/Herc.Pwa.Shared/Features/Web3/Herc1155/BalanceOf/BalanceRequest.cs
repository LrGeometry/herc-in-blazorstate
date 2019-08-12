namespace Herc.Pwa.Shared.Features.Web3.Herc1155.BalanceOf
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class BalanceRequest : BaseRequest, IRequest<BalanceResponse>
  {
    public const string Route = "api/balanceOf";

    public uint TemplateId { get; set; }

    public static string RouteFactory(int aId) => $"api/balanceOf?TemplateId={aId}";
  }
}