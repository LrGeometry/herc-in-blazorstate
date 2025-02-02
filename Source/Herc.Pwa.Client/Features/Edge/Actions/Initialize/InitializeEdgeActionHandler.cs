﻿namespace Herc.Pwa.Client.Features.Edge
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Microsoft.JSInterop;

  public partial class EdgeState
  {

    public class InitializeEdgeActionHandler : BaseHandler<InitailizeEdgeAction, EdgeState>
    {
      public InitializeEdgeActionHandler(IStore aStore, IJSRuntime aJSRuntime):base(aStore)
      {
        JSRuntime = aJSRuntime;
      }

      private IJSRuntime JSRuntime { get; }

      public override async Task<EdgeState> Handle(InitailizeEdgeAction aInitailizeEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeInterop_InitializeEdge);

        return EdgeState;
      }
    }
  }
}