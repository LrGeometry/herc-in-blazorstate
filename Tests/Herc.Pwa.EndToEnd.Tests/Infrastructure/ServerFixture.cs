﻿namespace Herc.Pwa.EndToEnd.Tests.Infrastructure
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Threading;
  using global::EndToEnd.Tests.Infrastructure;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Hosting.Server;
  using Microsoft.AspNetCore.Hosting.Server.Features;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;

  public class ServerFixture
  {
    private readonly Lazy<Uri> LazyUri;

    public ServerFixture()
    {
      LazyUri = new Lazy<Uri>(() =>
        new Uri(StartAndGetRootUri()));
    }

    public delegate IHostBuilder CreateHostBuilder(string[] args);

    public CreateHostBuilder CreateHostBuilderDelegate { get; set; }
    public AspNetEnvironment Environment { get; set; } = AspNetEnvironment.Production;
    public Uri RootUri => LazyUri.Value;
    private IHost Host { get; set; }

    /// <summary>
    /// Find the path to the server that you are testing.
    /// </summary>
    /// <param name="aProjectName"></param>
    /// <returns>The Path to the project</returns>
    protected static string FindSitePath(string aProjectName)
    {
      DirectoryInfo gitRootDirectory = new DirectoryService().FindSolutionRoot();
      string serverProjectName = "Server";
      serverProjectName = serverProjectName.Replace("_", "-");
      string path = Path.Combine(gitRootDirectory.FullName, "Source", serverProjectName);
      return path;
    }

    protected static void RunInBackgroundThread(Action aAction)
    {
      var isDone = new ManualResetEvent(false);

      new Thread(() =>
      {
        aAction();
        isDone.Set();
      }).Start();

      isDone.WaitOne();
    }

    protected IHost CreateWebHost()
    {
      if (CreateHostBuilderDelegate == null)
      {
        throw new InvalidOperationException(
            $"No value was provided for {nameof(CreateHostBuilderDelegate)}");
      }

      string sitePath = FindSitePath(
                CreateHostBuilderDelegate.Method.DeclaringType.Assembly.GetName().Name);

      IHostBuilder hostBuilder = CreateHostBuilderDelegate(new[]
      {
        "--urls", "http://127.0.0.1:0",
        "--contentroot", sitePath,
        "--environment", Environment.ToString(),
      });

      return hostBuilder.Build();
    }

    protected string StartAndGetRootUri()
    {
      Host = CreateWebHost();
      RunInBackgroundThread(Host.Start);
      return Host
        .Services
        .GetRequiredService<IServer>()
        .Features
        .Get<IServerAddressesFeature>()
        .Addresses.Single();
    }

  }
}