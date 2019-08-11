namespace Herc.Pwa.Server.Services.Web3.Herc1155.ViewTokenData
{
  using Herc.Pwa.Server.Configuration;
  using MediatR;
  using Nethereum.Contracts;
  using System.Threading;
  using System.Threading.Tasks;

  public class ViewTokenDataServerServiceHandler : IRequestHandler<ViewTokenDataServiceRequest, ViewTokenDataServiceResponse>
  {
    private readonly EthereumSettings EthereumSettings;
    private readonly Web3ContractManager Web3ContractManager;

    public ViewTokenDataServerServiceHandler(EthereumSettings ethereumSettings, Web3ContractManager web3ContractManager)
    {
      EthereumSettings = ethereumSettings;
      Web3ContractManager = web3ContractManager;
    }

    public async Task<ViewTokenDataServiceResponse> Handle(ViewTokenDataServiceRequest aViewTokenDataServiceRequest, CancellationToken aCancellationToken)
    {
      aViewTokenDataServiceRequest.FromAddress = EthereumSettings.TestAccountAddress;
      //aViewTokenDataServiceRequest.Gas = new Nethereum.Hex.HexTypes.HexBigInteger(900000);
      Contract nftCreatorContract = await Web3ContractManager.GetNftCreatorContract();
      Function<ViewTokenDataServiceRequest> function = nftCreatorContract.GetFunction<ViewTokenDataServiceRequest>();

      // using the functionMessage seems to error when it's a simple call. More research needed.
      // TokenId 5 is just a string
      // TokenId 4 Is a string "The First Minted NFT!"
      // TokenId 3 deserializes from base64 into ImmutableData type
      //
      // The Call signature is unavoidable at this point, I have tried the functionMessage, Strongly typing
      // the Function instantiation, creating CallInput, the only thing that seems to work is the explicit below
      //
      // Cramer ... Maybe the ABI was old and doesn't match the contract?
      //byte[] serializedImmutableData = Convert.FromBase64String(serializedBase64String);

      return new ViewTokenDataServiceResponse
      {
        TokenDataString = await function.CallAsync<string>(aViewTokenDataServiceRequest)
      };
    }
  }
}