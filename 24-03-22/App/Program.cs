using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:85/") };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    while (true)
    {
        var message = $"Hello world! {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}";
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "meu-fanout", body: body, basicProperties: null, routingKey: "");
        System.Console.WriteLine($"[x] {message}");
        Thread.Sleep(300);
    }
}
//por questão de praticidade
//criei o exchange e as filas manualmente