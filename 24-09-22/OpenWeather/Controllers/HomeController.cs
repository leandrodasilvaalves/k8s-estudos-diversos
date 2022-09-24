using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenWeather.Clients;
using OpenWeather.Models;

namespace OpenWeather.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IOpenWeatherService _weatherService;

    public HomeController(ILogger<HomeController> logger, IOpenWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Weather([FromQuery] int city = 3458329)
    {
        var result = await _weatherService.GetOpenWeatherAsync(city);
        return View(result.ValueOrDefault);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
