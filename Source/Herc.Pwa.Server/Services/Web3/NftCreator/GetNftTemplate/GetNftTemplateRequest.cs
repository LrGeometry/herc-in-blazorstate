namespace Herc.Pwa.Server.Services.Web3.NftCreator.GetNftTemplate
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "NFTTemplates")] 
  public class GetNftTemplateRequest : FunctionMessage, IRequest<GetNftTemplateResponse>
  {
    [Parameter(type: "uint", name: "id", order: 1)]
    public uint NftTemplateId { get; set; }
  }
}
