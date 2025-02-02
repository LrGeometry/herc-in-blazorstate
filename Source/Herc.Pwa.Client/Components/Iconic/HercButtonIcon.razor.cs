﻿namespace Herc.Pwa.Client.Components.Iconic
{
  using Microsoft.AspNetCore.Components;
  public class HercButtonIconBase : BaseComponent
  {

    [Parameter] protected string FillColor { get; set; } = "purple";

    [Parameter] protected string Size { get; set; } = "1em";
  }
}
