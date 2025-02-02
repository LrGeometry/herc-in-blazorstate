﻿namespace Herc.Pwa.Client.Features.Edge
{
  using MediatR;

  internal class SendNotification : INotification
  {
    public SendAction SendAction { get; set; }
    public string TransactionId { get; set; }
  }
}
