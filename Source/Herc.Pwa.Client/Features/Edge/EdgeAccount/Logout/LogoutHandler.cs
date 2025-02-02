﻿namespace Herc.Pwa.Client.Features.Edge.EdgeAccount
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;

  public partial class EdgeAccountState
  {
    public class LogoutHandler : BaseHandler<LogoutAction, EdgeAccountState>
    {
      public LogoutHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
      {
        JSRuntime = aJSRuntime;
      }
      private IJSRuntime JSRuntime { get; }
      public override async Task<EdgeAccountState> Handle(LogoutAction aShowLoginWindowEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeAccountInterop_Logout);
        EdgeAccountState.Initialize();
        Store.Reset(); // Clear the entire State.
        return EdgeAccountState;
      }
    }
  }
}