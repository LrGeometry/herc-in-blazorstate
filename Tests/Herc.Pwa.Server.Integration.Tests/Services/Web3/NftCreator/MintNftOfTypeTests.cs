//namespace Herc.Pwa.Server.Integration.Tests.Services.Web3.Contracts.NftCreator
//{
//  using System;
//  using MediatR;
//  using Microsoft.Extensions.DependencyInjection;
//  using Shouldly;
//  using System.Threading.Tasks;
//  using Herc.Pwa.Shared.Features.Web3;
//  using Herc.Pwa.Server.Services.Web3.Contracts.NftCreator.Functions.MintNftOfType;
//  using Herc.Pwa.Shared.Features.Web3.Contracts.NftCreator.MintNftOfType;
//  using Nethereum.Contracts;
//  using AnySerializer;
//  using Herc.Pwa.Server.Services.Web3.Contracts.NftCreator.ContractInstance;
//  using Herc.Pwa.Server.Services.Web3.Instance;
//  using Herc.Pwa.Shared.Constants.ContractConstants.NftCreator;
//  using Herc.Pwa.Server.Services.Web3.Contracts.NftCreator.Functions.GetNftTemplateCount;
//  using Herc.Pwa.Server.Services.Web3.Contracts.Herc1155;

//  // Below is nftType 4 for deserialization
//  class ImmutableData
//  {
//    public string Title = "The First Minted NFT!Take 2";
//    public DateTime Date = DateTime.Now;
//    public string MintedFrom = "Server.Services";
//  }

//  class MutableData
//  {
//    public string Mutable = "Data for versioning perhaps x2";
//  }
//  class MintNftOfTypeTests
//  {
//    public MintNftOfTypeTests(TestFixture aTestFixture)
//    {
//      ServiceProvider = aTestFixture.ServiceProvider;
//      Mediator = ServiceProvider.GetService<IMediator>();
//      NftCreator = ServiceProvider.GetService<NftCreatorInstance>();
//      NethWeb3 = ServiceProvider.GetService<NethWeb3>();
//    }

//    private IServiceProvider ServiceProvider { get; }
//    private IMediator Mediator { get; }
//    private NftCreatorInstance NftCreator { get; }
//    private NethWeb3 NethWeb3 { get; }

//    public async Task ShouldMintNftOfType()
//    {
//      // Arrange

//      Function<MintNftOfTypeFunctionInput> aMintNftOfTypeFunction = NftCreator.Instance.GetFunction<MintNftOfTypeFunctionInput>();

//      Nethereum.Contracts.ContractHandlers.IContractTransactionHandler<MintNftOfTypeFunctionInput> MintNftOfTypeFunctionHandler = NethWeb3.Instance.Eth.GetContractTransactionHandler<MintNftOfTypeFunctionInput>();

//      //byte[] serializedImmutable = Serializer.Serialize(new ImmutableData());
//      //byte[] serializedMutable = Serializer.Serialize(new MutableData());

//      //string base64StringifiedSerializedImmutable = Convert.ToBase64String(serializedImmutable);
//      //string base64StringifiedSerializedMutable = Convert.ToBase64String(serializedMutable);

//      var aMintNftOfTypeFunctionMessage = new MintNftOfTypeFunctionInput
//      {
//        Type = 4,
//        MutableDataString = "The Third Minted NFT!Take 3",
//        ImmutableDataString = "This Is MintingTest 3"
//      };

//      Nethereum.Hex.HexTypes.HexBigInteger gasEstimate = await MintNftOfTypeFunctionHandler.EstimateGasAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

//      aMintNftOfTypeFunctionMessage.Gas = gasEstimate.Value;

//      gasEstimate.Value.ShouldBeGreaterThan(0);

//      //Nethereum.RPC.Eth.DTOs.TransactionReceipt MintNftOfTypeTransactionReceipt = await MintNftOfTypeFunctionHandler.SendRequestAndWaitForReceiptAsync(NftCreatorAddresses.NftCreatorRinkebyAddress, aMintNftOfTypeFunctionMessage);

//      //System.Collections.Generic.List<EventLog<MintNftOutputEventDto>> MintNftOutput = MintNftOfTypeTransactionReceipt.DecodeAllEvents<MintNftOutputEventDto>();
//      //MintNftOfTypeTransactionReceipt.ShouldNotBe(null);
//      //MintNftOutput.Count.ShouldBeGreaterThan(0);

//    }
//  }
//}
