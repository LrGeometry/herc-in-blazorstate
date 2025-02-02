namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Threading.Tasks;
  using FluentValidation.Results;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePassword;

  public class ChangePasswordBase : BaseComponent
  {
    public const string Route = "/changePassword";
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
    public ValidationResult ValidationResult { get; set; }

    protected async Task ChangePassword()
    {

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = NewPassword,
        ConfirmPassword = ConfirmPassword
      };

      var validator = new ChangePasswordValidator();

      ValidationResult = validator.Validate(changePasswordAction);
      if (ValidationResult.IsValid)
      {
        await Mediator.Send(changePasswordAction);
        Console.WriteLine("Change the Route to the Home Page.");
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteAction { NewRoute = HomeBase.Route });
      }

    }

  }
}


