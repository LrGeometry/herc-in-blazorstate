namespace Herc.Pwa.Client.Pages
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;

  public class LoginPageBase : BaseComponent
  {
    public const string Route = "Login";


    protected override async Task OnAfterRenderAsync()
    {

      // Are we in the proper state for this page?
      if (EdgeAccountState.LoggedIn)
      {
          // Route them to Home Page
          await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteAction { NewRoute = HomeBase.Route });
      }
      else
      {
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteAction { NewRoute = EdgePageBase.Route });
      }
    }
  }
}
