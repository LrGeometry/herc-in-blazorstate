namespace Herc.Pwa.Server.Services.Web3.Herc1155.ViewTokenData
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "viewTokenData")] // This works
  public class ViewTokenDataServiceRequest : FunctionMessage, IRequest<ViewTokenDataServiceResponse>
  {
    public ViewTokenDataServiceRequest()
    {
      Gas = new Nethereum.Hex.HexTypes.HexBigInteger(900000);
      AmountToSend = new Nethereum.Hex.HexTypes.HexBigInteger(0);
    }

    [Parameter(type: "uint", name: "_id", order: 1)]
    public uint ViewTokenId { get; set; }
  }
}