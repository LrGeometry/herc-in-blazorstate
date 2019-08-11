namespace Herc.Pwa.Server.Services.Web3
{
  using Herc.Pwa.Server.Configuration;
  using Herc.Pwa.Server.Services.Web3.NftCreator;
  using Nethereum.Contracts;
  using Nethereum.Web3;
  using Nethereum.Web3.Accounts;
  using System.IO;
  using System.Reflection;
  using System.Text;
  using System.Threading.Tasks;

  public class Web3ContractManager
  {
    private readonly EthereumSettings EthereumSettings;

    private Contract NftCreatorContract;

    public Web3ContractManager(EthereumSettings aEthereumSettings)
    {
      EthereumSettings = aEthereumSettings;
      var account = new Account(EthereumSettings.TestAccountPrivateKey);
      Web3 = new Web3(account, EthereumSettings.Endpoint);
    }

    public Contract Herc1155Contract { get; }

    public Web3 Web3 { get; }

    private async Task<string> GetNftCreatorAbi()
    {
      Assembly assembly = typeof(Startup).Assembly;
      Stream resourceStream = assembly.GetManifestResourceStream("Herc.Pwa.Server.Services.Web3.Abis.NftCreator.json");
      using var reader = new StreamReader(resourceStream, Encoding.UTF8);
      return await reader.ReadToEndAsync();
    }

    public async Task<Contract> GetNftCreatorContract()
    {
      if (NftCreatorContract == null)
      {
        string nftCreatorAbi = await GetNftCreatorAbi();
        NftCreatorContract = Web3.Eth.GetContract(nftCreatorAbi, EthereumSettings.NftCreatorAddress);
      }
      return NftCreatorContract;
    }
  }
}