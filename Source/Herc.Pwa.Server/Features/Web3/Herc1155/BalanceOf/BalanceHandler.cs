namespace Herc.Pwa.Server.Features.Web3.Herc1155.BalanceOf
{
  using Herc.Pwa.Shared.Features.Web3.Herc1155.BalanceOf;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Services = Services.Web3.Herc1155.BalanceOf;

  public class BalanceHandler : IRequestHandler<BalanceRequest, BalanceResponse>
  {
    private readonly IMediator Mediator;

    public BalanceHandler(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    public async Task<BalanceResponse> Handle
    (
      BalanceRequest aBalanceRequest,
      CancellationToken aCancellationToken
    )
    {
      Services.BalanceResponse response = await Mediator.Send
      (
        new Services.BalanceRequest
        {
          TemplateId = aBalanceRequest.TemplateId
        }
      );

      return new BalanceResponse
      {
        Balance = response.Balance
      };
    }
  }
}