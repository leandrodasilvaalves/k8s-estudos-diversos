using System;

namespace webapp.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF {get; set;}

        public string? Summary { get; set; }

        public override string ToString()
        {
            return $"Date: {Date} | Summary: {Summary} | TemperatureC: {TemperatureC} | TemperatureF: {TemperatureF}";
        }
    }
}