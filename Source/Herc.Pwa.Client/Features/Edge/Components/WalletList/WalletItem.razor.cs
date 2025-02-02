﻿namespace Herc.Pwa.Client.Features.Edge.Components.WalletList
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge;
  using Microsoft.AspNetCore.Components;

  public class WalletItemBase : BaseComponent
  {

    public string EdgeCurrencyWalletId => EdgeCurrencyWallet.Id;

    [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

    public string Route => $"wallet/{EdgeCurrencyWallet.EncodedId}";
  }
}
