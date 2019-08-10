namespace Herc.Pwa.Client.Pages
{
  using Herc.Pwa.Client.Components;
  using Microsoft.AspNetCore.Components;

  public class WalletSendPageBase : BaseComponent
  {
    [Parameter] protected string EdgeCurrencyWalletId { get; set; }
    public static string Route(string aEdgeCurrencyWalletId) => $"/wallet/{aEdgeCurrencyWalletId}/Send";
  }
}