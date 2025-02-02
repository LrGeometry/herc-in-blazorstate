﻿namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge;

  public class EdgePageBase : BaseComponent
  {
    public const string Route = "edge";

    public EdgePageBase()
    {
      Console.WriteLine("EdgeModel constructor");
    }

    public async Task InitializeEdge()
    {
      Console.WriteLine("InitializeEdge");
      await Mediator.Send(new InitailizeEdgeAction());
      Console.WriteLine("Edge Initialized");
    }

    public async Task ShowLoginWindow()
    {
      Console.WriteLine("ShowLoginWindow Page.cs");
      await Mediator.Send(new ShowLoginWindowEdgeAction());
    }

    protected override async Task OnAfterRenderAsync()
    {
      Console.WriteLine("EdgeModel.OnAfterRenderAsync");
      Console.WriteLine(typeof(OnLoginAction).AssemblyQualifiedName);
      await InitializeEdge();
      await ShowLoginWindow();
      Console.WriteLine("After ShowLoginWindow");
    }
  }
}