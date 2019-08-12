namespace Herc.Pwa.Server.Features.Web3.NftCreator.CreateTemplate
{
  using Herc.Pwa.Shared.Features.Web3.NftCreator.CreateTemplate;
  using MediatR;
  using Nethereum.RPC.Eth.DTOs;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.NftCreator.CreateTemplate;

  public class CreateTemplateHandler : IRequestHandler<CreateTemplateRequest, CreateTemplateResponse>
  {
    IMediator Mediator { get; set; }

    public CreateTemplateHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }
    
    public async Task<CreateTemplateResponse> Handle
    (
      CreateTemplateRequest aCreateTemplateRequest,
      CancellationToken aCancellationToken
    )
    {
      var serviceCreateTemplateRequest = new Services.CreateTemplateRequest
      {
        Name = aCreateTemplateRequest.NewTemplateName,
        Symbol = aCreateTemplateRequest.NewTemplateSymbol,
        MintLimit = aCreateTemplateRequest.NewTemplateMintLimit,
        AttachedTokens = aCreateTemplateRequest.NewTemplateAttachedTokens
      };

      TransactionReceipt response = await Mediator.Send(serviceCreateTemplateRequest);

      return new CreateTemplateResponse
      {
        NewTemplateTransactionReceipt = response
      };
    }
  }
}