using System;

namespace CleanArchitecture.Api
{
#pragma warning disable 1591
    public class WeatherForecast
#pragma warning restore 1591
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
