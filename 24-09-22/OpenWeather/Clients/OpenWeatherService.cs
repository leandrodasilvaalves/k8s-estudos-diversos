using FluentResults;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using OpenWeather.Models;

namespace OpenWeather.Clients
{

    public class OpenWeatherService : IOpenWeatherService
    {
        public OpenWeatherService(IOptionsMonitor<OpenWeatherOptions> options)
        {
            Options = options.CurrentValue;
        }

        public OpenWeatherOptions Options { get; }

        public async Task<Result<Root>> GetOpenWeatherAsync(int cityId)
        {
            var weather = await Options.BaseUrl
                .AppendPathSegment("forecast")
                .SetQueryParams(new
                {
                    id = cityId,
                    appid = Options.Secret
                })
                .GetJsonAsync<Root>();

            return Result.Ok(weather);
        }
    }
}