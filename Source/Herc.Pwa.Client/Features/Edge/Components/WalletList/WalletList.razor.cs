﻿namespace Herc.Pwa.Client.Features.Edge.Components.WalletList
{
  using System.Collections.Generic;
  using System.Linq;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge;
  public class WalletListBase : BaseComponent
  {
    public List<EdgeCurrencyWallet> EdgeCurrencyWallets => EdgeCurrencyWalletsState.EdgeCurrencyWallets.Values.ToList();
  }
}
