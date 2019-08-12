namespace Herc.Pwa.Server.Services.Web3.Herc1155.BalanceOf
{
  using Herc.Pwa.Server.Configuration;
  using Herc.Pwa.Server.Services.Web3;
  using MediatR;
  using Nethereum.Contracts;
  using System.Threading;
  using System.Threading.Tasks;

  public class BalanceHandler : IRequestHandler<BalanceRequest, BalanceResponse>
  {
    private readonly EthereumSettings EthereumSettings;
    private readonly Web3ContractManager Web3ContractManager;

    public BalanceHandler(Web3ContractManager aWeb3ContractManager, EthereumSettings aEthereumSettings)
    {
      EthereumSettings = aEthereumSettings;
      Web3ContractManager = aWeb3ContractManager;
    }

    public async Task<BalanceResponse> Handle(BalanceRequest aBalanceOfServiceRequest, CancellationToken aCancellationToken)
    {
      aBalanceOfServiceRequest.Owner = EthereumSettings.TestAccountAddress;
      Contract nftCreatorContract = await Web3ContractManager.GetNftCreatorContract();
      Function<BalanceRequest> function = nftCreatorContract.GetFunction<BalanceRequest>();

      return new BalanceResponse
      {
        Balance = await function.CallAsync<int>(aBalanceOfServiceRequest)
      };
    }
  }
}