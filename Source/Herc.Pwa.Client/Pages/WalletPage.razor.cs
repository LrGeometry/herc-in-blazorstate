namespace Herc.Pwa.Client.Pages
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge;

  public class WalletPageBase : BaseComponent
  {
    public const string Route = "/wallet";
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;
  }
}