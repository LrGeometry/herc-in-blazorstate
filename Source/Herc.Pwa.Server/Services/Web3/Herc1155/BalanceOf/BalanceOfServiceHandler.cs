namespace Herc.Pwa.Server.Services.Web3.Herc1155.BalanceOf
{
  using Herc.Pwa.Server.Configuration;
  using Herc.Pwa.Server.Services.Web3;
  using MediatR;
  using Nethereum.Contracts;
  using System.Threading;
  using System.Threading.Tasks;

  public class BalanceOfServiceHandler : IRequestHandler<BalanceOfServiceRequest, BalanceOfServiceResponse>
  {
    private readonly EthereumSettings EthereumSettings;
    private readonly Web3ContractManager Web3ContractManager;

    public BalanceOfServiceHandler(Web3ContractManager web3ContractManager, EthereumSettings ethereumSettings)
    {
      Web3ContractManager = web3ContractManager;
      EthereumSettings = ethereumSettings;
    }

    public async Task<BalanceOfServiceResponse> Handle(BalanceOfServiceRequest aBalanceOfServiceRequest, CancellationToken aCancellationToken)
    {
      aBalanceOfServiceRequest.Owner = EthereumSettings.TestAccountAddress;
      Contract nftCreatorContract = await Web3ContractManager.GetNftCreatorContract();
      Function<BalanceOfServiceRequest> function = nftCreatorContract.GetFunction<BalanceOfServiceRequest>();

      return new BalanceOfServiceResponse
      {
        Balance = await function.CallAsync<int>(aBalanceOfServiceRequest)
      };
    }
  }
}