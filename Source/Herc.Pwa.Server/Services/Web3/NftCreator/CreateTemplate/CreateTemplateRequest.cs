namespace Herc.Pwa.Server.Services.Web3.NftCreator.CreateTemplate
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;
  using Nethereum.RPC.Eth.DTOs;
  using System.Numerics;

  [Function(name: "CreateTemplate")]
  public class CreateTemplateRequest : FunctionMessage, IRequest<TransactionReceipt>
  {
    [Parameter("uint", "attachedTokens", 4)]
    public BigInteger AttachedTokens { get; set; }

    [Parameter("uint", "mintlimit", 3)]
    public BigInteger MintLimit { get; set; }

    [Parameter(type: "string", name: "name", 1)]
    public string Name { get; set; }

    [Parameter("string", "symbol", 2)]
    public string Symbol { get; set; }
  }
}
