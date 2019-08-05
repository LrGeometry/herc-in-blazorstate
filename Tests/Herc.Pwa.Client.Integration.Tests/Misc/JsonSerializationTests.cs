namespace Herc.Pwa.Server.Integration.Tests.Misc
{
  using Herc.Pwa.Client.Features.Edge;
  using Shouldly;
  using System;
  using System.Linq;
  using System.Text.Json;

  class JsonSerializationTests
  {
    public JsonSerializerOptions JsonSerializerOptions { get; }

    public JsonSerializationTests()
    {

      JsonSerializerOptions = new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };
    }
    public void GoodSingle()
    {
      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\GoodSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = JsonSerializer.Deserialize<UpdateEdgeCurrencyWalletAction>(json, JsonSerializerOptions);
      updateEdgeCurrencyWalletAction.Id.ShouldBe("JWTVcPqgM0jdi43heA7DO3Kx/wTXeYDcj/t6RfSXyOE=");
      updateEdgeCurrencyWalletAction.Keys.Count.ShouldBe(4);
      updateEdgeCurrencyWalletAction.EdgeTransactions.Count.ShouldBe(1);
      updateEdgeCurrencyWalletAction.EdgeTransactions.Any(t => t.TxId == "0x7462c57a292a619bff7dc87ec248ed4ff00f32bde7e89ded4736a9e83697a3c7").ShouldBeTrue();
    }

    public void AnotherSample()
    {

      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\UpdateEdgeCurrencyWalletAction.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = JsonSerializer.Deserialize<UpdateEdgeCurrencyWalletAction>
      (
        json,
        JsonSerializerOptions
      );
      updateEdgeCurrencyWalletAction.Id.ShouldBe("1fu3+YTRMVRb6R6uwO7DDCH31iVKkBMtkYHLA0P3hMo=");
      updateEdgeCurrencyWalletAction.Keys.Count.ShouldBe(4);
    }

    // Skip: By making private will skip the test
    private void BadSingle()
    {
      // The amountSatoshi causes the error it should be a string.
      // But given we don't care about the field we now remove it prior to serialization
      string currentDirectory = Environment.CurrentDirectory;
      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\BadSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = JsonSerializer.Deserialize<UpdateEdgeCurrencyWalletAction>(json);
    }

  }
}
