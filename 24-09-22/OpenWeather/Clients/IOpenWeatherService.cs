using FluentResults;
using OpenWeather.Models;

namespace OpenWeather.Clients
{
    public interface IOpenWeatherService
    {
        Task<Result<Root>> GetOpenWeatherAsync(int cityId);
    }
}