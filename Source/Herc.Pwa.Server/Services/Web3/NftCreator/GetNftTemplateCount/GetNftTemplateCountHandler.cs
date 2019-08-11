namespace Herc.Pwa.Server.Services.Web3.NftCreator.GetNftTemplateCount
{
  using MediatR;
  using Nethereum.Contracts;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetNftTemplateCountHandler : IRequestHandler<GetNftTemplateCountRequest, GetNftTemplateCountResponse>
  {
    public GetNftTemplateCountHandler(Web3ContractManager aWeb3ContractManager)
    {
      Web3ContractManager = aWeb3ContractManager;
    }

    private Web3ContractManager Web3ContractManager { get; set; }

    public async Task<GetNftTemplateCountResponse> Handle(GetNftTemplateCountRequest aGetNftTemplateCountRequest, CancellationToken aCancellationToken)
    {
      Function<GetNftTemplateCountRequest> function =
        Web3ContractManager.NftCreatorContract.GetFunction<GetNftTemplateCountRequest>();
      var getNftTemplateCountResponse = new GetNftTemplateCountResponse
      {
        Count = await function.CallAsync<uint>()
      };

      return getNftTemplateCountResponse;
    }
  }
}