namespace Herc.Pwa.Server.Services.Web3.Herc1155.BalanceOf
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "balanceOf")]
  public class BalanceOfServiceRequest : FunctionMessage, IRequest<BalanceOfServiceResponse>
  {
    [Parameter(type: "uint", name: "id")]
    public uint Id { get; set; }

    [Parameter(type: "address", name: "owner", order: 1)]
    public string Owner { get; set; }
  }
}