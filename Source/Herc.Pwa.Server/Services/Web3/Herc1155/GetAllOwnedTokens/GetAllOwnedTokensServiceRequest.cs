namespace Herc.Pwa.Server.Services.Web3.Herc1155.GetAllOwnedTokens
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;

  [Function(name: "getAllOwnedTokens")] // This works
  public class GetAllOwnedTokensServiceRequest : FunctionMessage, IRequest<GetAllOwnedTokensServiceResponse>
  {
    [Parameter(type: "address", name: "owner", order: 1)]
    public string Owner { get; set; }
  }
}