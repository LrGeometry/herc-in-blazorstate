﻿namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using BlazorState;

  public partial class EdgeCurrencyWalletsState : State<EdgeCurrencyWalletsState>
  {
    public EdgeCurrencyWalletsState()
    {
      EdgeCurrencyWallets = new Dictionary<string, EdgeCurrencyWallet>();
    }
    protected EdgeCurrencyWalletsState(EdgeCurrencyWalletsState aEdgeCurrencyWalletsState) : this()
    {
      Console.WriteLine("EdgeCurrencyWalletState");

      aEdgeCurrencyWalletsState
        .EdgeCurrencyWallets
        .ToList()
        .ForEach
        (
          aKeyValuePair =>
            EdgeCurrencyWallets[aKeyValuePair.Key] =
              aKeyValuePair.Value.Clone() as EdgeCurrencyWallet
        );

      SelectedEdgeCurrencyWalletId = aEdgeCurrencyWalletsState.SelectedEdgeCurrencyWalletId;
    }

    //public override object Clone() => new EdgeCurrencyWalletsState(this);

    protected override void Initialize() => EdgeCurrencyWallets = new Dictionary<string, EdgeCurrencyWallet>();
  }

}