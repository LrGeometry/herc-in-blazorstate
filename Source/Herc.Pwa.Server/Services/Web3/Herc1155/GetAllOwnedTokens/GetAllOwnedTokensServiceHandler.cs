namespace Herc.Pwa.Server.Services.Web3.Herc1155.GetAllOwnedTokens
{
  using Herc.Pwa.Server.Configuration;
  using MediatR;
  using Nethereum.Contracts;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetAllOwnedTokensServerServiceHandler : IRequestHandler<GetAllOwnedTokensServiceRequest, GetAllOwnedTokensServiceResponse>
  {
    private readonly EthereumSettings EthereumSettings;
    private readonly Web3ContractManager Web3ContractManager;

    public GetAllOwnedTokensServerServiceHandler(Web3ContractManager web3ContractManager, EthereumSettings ethereumSettings)
    {
      Web3ContractManager = web3ContractManager;
      EthereumSettings = ethereumSettings;
    }

    public async Task<GetAllOwnedTokensServiceResponse> Handle(GetAllOwnedTokensServiceRequest aGetAllOwnedTokensServiceRequest, CancellationToken aCancellationToken)
    {
      aGetAllOwnedTokensServiceRequest.Owner = EthereumSettings.TestAccountAddress;
      Contract nftCreatorContract = await Web3ContractManager.GetNftCreatorContract();
      Function<GetAllOwnedTokensServiceRequest> function = nftCreatorContract.GetFunction<GetAllOwnedTokensServiceRequest>();

      return new GetAllOwnedTokensServiceResponse
      {
        TokenIdList = await function.CallAsync<List<uint>>(aGetAllOwnedTokensServiceRequest)
      };
    }
  }
}