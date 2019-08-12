namespace Herc.Pwa.Shared.Features.WeatherForecast
{
  using System;
  using System.Collections.Generic;
  using Herc.Pwa.Shared.Features.Base;

  public class GetWeatherForecastsResponse : BaseResponse
  {
    /// <summary>
    /// a default constructor is required for deserialization
    /// </summary>
    public GetWeatherForecastsResponse() { }

    public GetWeatherForecastsResponse(Guid aRequestId) : base(aRequestId)
    {
      WeatherForecasts = new List<WeatherForecastDto>();
    }
    
    public List<WeatherForecastDto> WeatherForecasts { get; set; }
  }
}