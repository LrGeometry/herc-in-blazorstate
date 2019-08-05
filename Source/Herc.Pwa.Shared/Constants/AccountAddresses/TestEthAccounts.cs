namespace Herc.Pwa.Shared.Constants.AccountAddresses
{
  using Nethereum.Web3.Accounts;

  public class TestEthAccount
  {
    internal const string TestEthPrivateKey = "307F685A376C5BF8296B4BE1D3703F068315BCD3115280B52C4CA0F8BA83C474";

    public const string TestEthAccountAddress = "0x12833d6fADd206dEd2fcE84936d8D78326AB8EfA";

    public TestEthAccount()
    {
      TesterAcct = new Account(TestEthPrivateKey);
    }

    public Account TesterAcct { get; set; }
  }
}