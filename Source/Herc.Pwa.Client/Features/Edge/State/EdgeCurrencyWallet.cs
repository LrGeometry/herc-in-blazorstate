namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;

  public class EdgeCurrencyWallet : ICloneable
  {
    private string _SelectedCurrencyCode;

    public EdgeCurrencyWallet()
    {
      EdgeTransactions = new List<EdgeTransaction>();
      Balances = new Dictionary<string, string>();
      Keys = new Dictionary<string, string>();
    }

    public Dictionary<string, string> Balances { get; set; }
    public List<EdgeTransaction> EdgeTransactions { get; set; }
    public string EncodedId => Id;
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public string Name { get; set; }

    public string SelectedCurrencyCode
    {
      get => _SelectedCurrencyCode ?? Balances?.Keys.FirstOrDefault();
      set => _SelectedCurrencyCode = value;
    }

    public object Clone()
    {
      var clone = MemberwiseClone() as EdgeCurrencyWallet;
      clone.Keys = new Dictionary<string, string>(Keys);
      clone.Balances = new Dictionary<string, string>(Balances);

      clone.EdgeTransactions = new List<EdgeTransaction>();

      EdgeTransactions.ForEach((aEdgeTransaction) =>
      {
        clone.EdgeTransactions.Add(aEdgeTransaction.Clone() as EdgeTransaction);
      });

      return clone;
    }
  }
}