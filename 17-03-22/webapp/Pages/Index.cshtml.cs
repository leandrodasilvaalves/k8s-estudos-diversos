using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using webapp.Models;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace WebAppK8s.Pages;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;


    private readonly ILogger<IndexModel> _logger;
    private readonly ApiOptions _options;
    
    public string Hostname { get; set; }
    public string IP { get; set; }
    public IEnumerable<WeatherForecast> ForeCasts { get; set; }
    public string TestEnv { get; set; }


    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IOptionsMonitor<ApiOptions> options)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _options = options.CurrentValue;
    }

    public async Task OnGet()
    {
        Hostname = Dns.GetHostName();
        IP = Dns.GetHostAddresses(Hostname).FirstOrDefault().ToString();
        ForeCasts = await GetForecast();
        TestEnv = _options.ForeCastApiUrl;
    }

    private async Task<IEnumerable<WeatherForecast>> GetForecast()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(_options.ForeCastApiUrl);
        if (response.IsSuccessStatusCode)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<WeatherForecast>>(body, options);
            return result;
        }

        return new List<WeatherForecast>();
    }
}
