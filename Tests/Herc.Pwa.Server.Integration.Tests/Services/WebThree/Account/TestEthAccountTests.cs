namespace Herc.Pwa.Server.Integration.Tests.Services.WebThree.Account
{
  using Herc.Pwa.Shared.Constants.AccountAddresses;
  using Shouldly;

  internal class TestEthAccountTests
  {
    public void ShouldCountainEthereumWeb3Account()
    {
      // Arrange
      // Act
      TestEthAccount TestEthAccount = new TestEthAccount();
      // Assert
      TestEthAccount.TesterAcct.ShouldNotBe(null);
    }
  }
}