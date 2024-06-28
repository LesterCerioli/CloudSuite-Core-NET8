using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Text;

namespace CloudSuite.Core.Messaging.RabbitMq.Productors
{
    public class AddressCoreProducer : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly RabbitMqSettings _settings;

        public AddressCoreProducer(IOptions<RabbitMqSettings> options)
        {
            _settings = options.Value;

            var factory = new ConnectionFactory()
            {
                HostName = _settings.RabbitMqConfiguration.HostName,
                UserName = _settings.RabbitMqConfiguration.UserName,
                Password = _settings.RabbitMqConfiguration.Password,
                VirtualHost = _settings.RabbitMqConfiguration.VirtualHost
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: _settings.RabbitMqConfiguration.ExchangeName, type: "direct");
                _channel.QueueDeclare(queue: _settings.RabbitMqConfiguration.Queues["AddressCore"], durable: true, exclusive: false, autoDelete: false, arguments: null);
            }
            catch (Exception ex)
            {
                // Trate exceções de conexão ou criação de canal aqui
                Console.WriteLine($"Erro ao configurar o RabbitMQ: {ex.Message}");
                throw;
            }
        }

        public void Publish(string message)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(message);
                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;

                _channel.BasicPublish(exchange: _settings.RabbitMqConfiguration.ExchangeName,
                                      routingKey: _settings.RabbitMqConfiguration.RoutingKeys["AddressCore"],
                                      basicProperties: properties,
                                      body: body);
            }
            catch (Exception ex)
            {
                // Trate exceções ao publicar mensagem aqui
                Console.WriteLine($"Erro ao publicar mensagem no RabbitMQ: {ex.Message}");
                throw;
            }
        }

        // Implement IDisposable para liberar recursos
        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
