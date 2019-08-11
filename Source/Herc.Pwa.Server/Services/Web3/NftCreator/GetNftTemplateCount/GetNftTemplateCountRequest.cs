namespace Herc.Pwa.Server.Services.Web3.NftCreator.GetNftTemplateCount
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;

  [Function(name: "totalNFTs","uint")]
  public class GetNftTemplateCountRequest : IRequest<GetNftTemplateCountResponse> { }
}