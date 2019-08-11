namespace Herc.Pwa.Server.Services.Web3.NftCreator.GetNftTemplate
{
  using Nethereum.ABI.FunctionEncoding.Attributes;

  [FunctionOutput]
  public class GetNftTemplateResponse : IFunctionOutputDTO
  {
    [Parameter("string", "name", 1)]
    public string Name { get; set; }

    [Parameter("string", "symbol", 2)]
    public string Symbol { get; set; }

    [Parameter("uint", "mintlimit", 3)]
    public int MintLimit { get; set; }

    [Parameter("uint", "attachedTokens", 4)]
    public int AttachedTokens { get; set; }

  }
}
