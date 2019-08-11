namespace Herc.Pwa.Server.Services.Web3.Herc1155.ViewMutableData
{
  using MediatR;
  using Nethereum.Contracts;
  using System.Threading;
  using System.Threading.Tasks;

  public class ViewMutableDataServiceHandler : IRequestHandler<ViewMutableDataServiceRequest, ViewMutableDataServiceResponse>
  {
    private readonly Web3ContractManager Web3ContractManager;

    public ViewMutableDataServiceHandler(Web3ContractManager aWeb3ContractManager)
    {
      Web3ContractManager = aWeb3ContractManager;
    }

    public async Task<ViewMutableDataServiceResponse> Handle(ViewMutableDataServiceRequest aViewMutableDataServiceRequest, CancellationToken aCancellationToken)
    {
      Contract nftCreatorContract = await Web3ContractManager.GetNftCreatorContract();
      Function<ViewMutableDataServiceRequest> function = nftCreatorContract.GetFunction<ViewMutableDataServiceRequest>();

      return new ViewMutableDataServiceResponse
      {
        MutableDataString = await function.CallAsync<string>(aViewMutableDataServiceRequest)
      };
    }
  }
}