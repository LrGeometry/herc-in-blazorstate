namespace Herc.Pwa.Server.Integration.Tests.Services.Web3.NftCreator
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Services.Web3;
  using Herc.Pwa.Server.Services.Web3.NftCreator.CreateTemplate;
  using Nethereum.RPC.Eth.DTOs;

  class CreateTemplateTests
  {
    public CreateTemplateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Web3ContractManager = ServiceProvider.GetService<Web3ContractManager>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private Web3ContractManager Web3ContractManager { get; }
    
    public async Task ShouldCreateNftTemplate()
    {
      // Arrange
      var createTemplateRequest = new CreateTemplateRequest
      {
        Name = "TestTemplate1",
        AttachedTokens = 3,
        Symbol = "CRAM",
        MintLimit = 10
      };

      // Act

      TransactionReceipt transactionReceipt = await Mediator.Send(createTemplateRequest);

      // Assert
      transactionReceipt.BlockHash.ShouldNotBeNullOrEmpty();
      transactionReceipt.BlockNumber.ShouldNotBeNull();
      transactionReceipt.TransactionHash.ShouldNotBeNullOrEmpty();
    }
  }
}
