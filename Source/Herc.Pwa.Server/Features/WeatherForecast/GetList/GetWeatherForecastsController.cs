namespace Herc.Pwa.Server.Features.WeatherForecast
{
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.WeatherForecast;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [Route(GetWeatherForecastsRequest.Route)]
  public class WeatherForecastsController : BaseController<GetWeatherForecastsRequest, GetWeatherForecastsResponse>
  {
    public async Task<IActionResult> Get(GetWeatherForecastsRequest aRequest) => await Send(aRequest);
  }
}