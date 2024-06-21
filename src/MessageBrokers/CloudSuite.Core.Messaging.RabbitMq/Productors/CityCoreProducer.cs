using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CloudSuite.Core.Messaging.RabbitMq.Productors
{
    public class CityCoreProducer
    {
        private readonly RabbitMqSettings _settings;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public CityCoreProducer(RabbitMqSettings settings)
        {
            _settings = settings;
            var factory = new ConnectionFactory()
            {
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password,
                VirtualHost = _settings.VirtualHost
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: _settings.ExchangeName, type: "direct");
            _channel.QueueDeclare(queue: _settings.QueueName_City_Core, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: _settings.QueueName_City_Core, exchange: _settings.ExchangeName, routingKey: _settings.RountingKey_City_Core);

        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: _settings.ExchangeName,
                                  routingKey: _settings.RountingKey_City_Core,
                                  basicProperties: properties,
                                  body: body);
        }

        // Optional: Implement IDisposable to clean up resources
        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
