namespace Herc.Pwa.Client.Layouts.HercLayout
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Pages;
  using Microsoft.AspNetCore.Components;

  public class HercLayoutBase : BaseComponent, IComponent
  {

    [Parameter] protected RenderFragment Body { get; set; }

    protected override async Task OnAfterRenderAsync()
    {
      // Are we in the proper state for this page?
      if (!EdgeAccountState.LoggedIn)
      {
        // Route to Edge to Login
        _ = await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteAction { NewRoute = EdgePageBase.Route });
      }
    }
  }
}
