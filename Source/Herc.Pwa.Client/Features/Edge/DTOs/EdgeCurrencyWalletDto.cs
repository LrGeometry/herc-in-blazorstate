namespace Herc.Pwa.Client.Features.Edge
{
  using Herc.Pwa.Client.Features.Edge.Dtos;
  using System.Collections.Generic;

  public class EdgeCurrencyWalletDto
  {
    public Dictionary<string, string> Balances { get; set; }
    public List<EdgeTransactionDto> EdgeTransactions { get; set; }
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
  }
}