namespace Herc.Pwa.Server.Services.Web3.Herc1155.ViewMutableData
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "viewMutableData")]
  public class ViewMutableDataServiceRequest : FunctionMessage, IRequest<ViewMutableDataServiceResponse>
  {
    [Parameter(type: "uint", name: "_id", order: 1)]
    public uint ViewTokenId { get; set; }
  }
}