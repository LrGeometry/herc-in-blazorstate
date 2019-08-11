namespace Herc.Pwa.Server.Services.Web3.NftCreator.CreateTemplate
{
  using Herc.Pwa.Server.Configuration;
  using MediatR;
  using Nethereum.Contracts.ContractHandlers;
  using Nethereum.Hex.HexTypes;
  using Nethereum.RPC.Eth.DTOs;
  using System.Threading;
  using System.Threading.Tasks;

  public class CreateTemplateHandler : IRequestHandler<CreateTemplateRequest, TransactionReceipt>
  {
    private readonly Web3ContractManager Web3ContractManager;
    private readonly EthereumSettings EthereumSettings;

    public CreateTemplateHandler(Web3ContractManager aWeb3ContractManager, EthereumSettings aEthereumSettings)
    {
      Web3ContractManager = aWeb3ContractManager;
      EthereumSettings = aEthereumSettings;
    }


    public async Task<TransactionReceipt> Handle(CreateTemplateRequest aCreateTemplateRequest, CancellationToken aCancellationToken)
    {
      IContractTransactionHandler<CreateTemplateRequest> contractTransactionHandler =
        Web3ContractManager.Web3.Eth.GetContractTransactionHandler<CreateTemplateRequest>();

      HexBigInteger gasEstimate =
        await contractTransactionHandler.EstimateGasAsync(EthereumSettings.NftCreatorAddress, aCreateTemplateRequest);
      aCreateTemplateRequest.Gas = gasEstimate;
      return await contractTransactionHandler
        .SendRequestAndWaitForReceiptAsync(EthereumSettings.NftCreatorAddress, aCreateTemplateRequest);
    }
  }
}