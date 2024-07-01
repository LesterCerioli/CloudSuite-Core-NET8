using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace CloudSuite.Core.Messaging.RabbitMq.Productors
{
    public class CompanyCoreProducer : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly RabbitMqSettings _settings;

        public CompanyCoreProducer(IOptions<RabbitMqSettings> options)
        {
            _settings = options.Value;

            var factory = new ConnectionFactory()
            {
                HostName = _settings.RabbitMqConfiguration.HostName,
                UserName = _settings.RabbitMqConfiguration.UserName,
                Password = _settings.RabbitMqConfiguration.Password,
                VirtualHost = _settings.RabbitMqConfiguration.VirtualHost
            };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: _settings.RabbitMqConfiguration.ExchangeName, type: "direct");
                _channel.QueueDeclare(queue: _settings.RabbitMqConfiguration.Queues["Company"], durable: true, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueBind(queue: _settings.RabbitMqConfiguration.Queues["Company"], exchange: _settings.RabbitMqConfiguration.ExchangeName, routingKey: _settings.RabbitMqConfiguration.RoutingKeys["Company"]);
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: _settings.RabbitMqConfiguration.ExchangeName,
                                  routingKey: _settings.RabbitMqConfiguration.RoutingKeys["Company"],
                                  basicProperties: properties,
                                  body: body);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
