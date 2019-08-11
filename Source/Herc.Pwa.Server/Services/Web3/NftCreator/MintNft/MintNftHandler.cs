namespace Herc.Pwa.Server.Services.Web3.NftCreator.MintNft
{
  using Herc.Pwa.Server.Configuration;
  using MediatR;
  using Nethereum.Contracts;
  using Nethereum.Contracts.ContractHandlers;
  using Nethereum.Hex.HexTypes;
  using Nethereum.RPC.Eth.DTOs;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  public class MintNftHandler : IRequestHandler<MintNftRequest, MintNftResponse>
  {
    private readonly EthereumSettings EthereumSettings;
    private readonly Web3ContractManager Web3ContractManager;

    public MintNftHandler(Web3ContractManager web3ContractManager, EthereumSettings ethereumSettings)
    {
      Web3ContractManager = web3ContractManager;
      EthereumSettings = ethereumSettings;
    }

    public async Task<MintNftResponse> Handle(MintNftRequest aMintNftRequest, CancellationToken aCancellationToken)
    {
      IContractTransactionHandler<MintNftRequest> contractTransactionHandler =
        Web3ContractManager.Web3.Eth.GetContractTransactionHandler<MintNftRequest>();

      HexBigInteger gasEstimate =
        await contractTransactionHandler.EstimateGasAsync(EthereumSettings.NftCreatorAddress, aMintNftRequest);
      aMintNftRequest.Gas = gasEstimate;
      TransactionReceipt transactionReceipt = await contractTransactionHandler
        .SendRequestAndWaitForReceiptAsync(EthereumSettings.NftCreatorAddress, aMintNftRequest);

      List<EventLog<MintNftEventDto>> mintNftEventDtos = transactionReceipt.DecodeAllEvents<MintNftEventDto>();

      return new MintNftResponse
      {
        MintNftEventDto = mintNftEventDtos.FirstOrDefault()?.Event,
        TransactionReceipt = transactionReceipt
      };
    }
  }
}