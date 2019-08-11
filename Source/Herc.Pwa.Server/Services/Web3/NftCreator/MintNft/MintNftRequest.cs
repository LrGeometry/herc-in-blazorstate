namespace Herc.Pwa.Server.Services.Web3.NftCreator.MintNft
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;
  using Nethereum.RPC.Eth.DTOs;

  // Mints the selected NFT template
  // Triggers Herc1155 Transfer Single Event
  [Function("mintNFT")]
  public class MintNftRequest: FunctionMessage, IRequest<MintNftResponse>
  {
    [Parameter("string", "data", 2)]
    public string ImmutableDataString { get; set; }

    [Parameter("string", "mutabledata", 3)]
    public string MutableDataString { get; set; }

    [Parameter(type: "uint", name: "type", 1)]
    public int Type { get; set; }
  }
}