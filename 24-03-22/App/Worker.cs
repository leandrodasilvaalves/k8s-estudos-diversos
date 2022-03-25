using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using RabbitMQ.Client;

namespace App;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:85/") };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = $"Hello world! {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "meu-fanout", body: body, basicProperties: null, routingKey: "");                
                _logger.LogInformation($"[x] {message}");                
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
//por questão de praticidade
//criei o exchange e as filas manualmente