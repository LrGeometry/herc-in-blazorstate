namespace Herc.Pwa.Client.Pages
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Clipboard;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;

  public class WalletReceivePageBase : BaseComponent
  {
    private EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];
    [Parameter] protected string EdgeCurrencyWalletId { get; set; }
    [Inject] public AmountConverter AmountConverter { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }
    public string ReceiveAddress => EdgeCurrencyWallet.Keys["ethereumAddress"];

    public string WalletName => EdgeCurrencyWallet.Name;

    protected async Task CopyToClipboardAsync() =>
      await JSRuntime.InvokeAsync<object>(ClipboardInteropMethodNames.ClipboardInterop_WriteText, ReceiveAddress);

    public static string Route(string aEdgeCurrencyWalletId) => $"/wallet/{aEdgeCurrencyWalletId}/Receive";
  }
}