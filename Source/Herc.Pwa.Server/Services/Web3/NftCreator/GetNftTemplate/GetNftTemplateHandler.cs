namespace Herc.Pwa.Server.Services.Web3.NftCreator.GetNftTemplate
{
  using MediatR;
  using Nethereum.ABI.FunctionEncoding.Attributes;
  using Nethereum.Contracts;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetNftHandler : IRequestHandler<GetNftTemplateRequest, GetNftTemplateResponse>
  {
    public GetNftHandler(Web3ContractManager aWeb3ContractManager)
    {
      Web3ContractManager = aWeb3ContractManager;
    }

    private Web3ContractManager Web3ContractManager { get; set; }

    public async Task<GetNftTemplateResponse> Handle(GetNftTemplateRequest aGetNftRequest, CancellationToken aCancellationToken)
    {
      Contract nftCreatorContract = await Web3ContractManager.GetNftCreatorContract();
      Function<GetNftTemplateRequest> function = nftCreatorContract.GetFunction<GetNftTemplateRequest>();

      GetNftTemplateResponse getNftResponse = 
        await function.CallDeserializingToObjectAsync<GetNftTemplateResponse>(aGetNftRequest);
      return getNftResponse;
    }
  }
}