﻿namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;

  public class EdgeModel : BaseComponent
  {
    public const string Route = "edge";

    public EdgeModel()
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

    protected override async Task OnInitAsync()
    {
      Console.WriteLine("EdgeModel.OnInitAsync");
      Console.WriteLine(typeof(OnLoginAction).AssemblyQualifiedName);
      await InitializeEdge();
      await ShowLoginWindow();
      Console.WriteLine("After ShowLoginWindow");
    }
  }
}