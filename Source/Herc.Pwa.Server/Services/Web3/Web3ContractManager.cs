namespace Herc.Pwa.Server.Services.Web3
{
  using Herc.Pwa.Server.Configuration;
  using Herc.Pwa.Server.Services.Web3.NftCreator;
  using Nethereum.Contracts;
  using Nethereum.Web3;
  using Nethereum.Web3.Accounts;

  public class Web3ContractManager
  {
    private readonly EthereumSettings EthereumSettings;

    public Web3ContractManager(EthereumSettings aEthereumSettings)
    {
      EthereumSettings = aEthereumSettings;
      var account = new Account(EthereumSettings.TestAccountPrivateKey);
      Web3 = new Web3(account, EthereumSettings.Endpoint);

      NftCreatorContract = Web3.Eth.GetContract(NftCreatorConstants.Abi, EthereumSettings.NftCreatorAddress);
    }

    public Contract Herc1155Contract { get; }
    public Contract NftCreatorContract { get; }
    public Web3 Web3 { get; }
  }
}