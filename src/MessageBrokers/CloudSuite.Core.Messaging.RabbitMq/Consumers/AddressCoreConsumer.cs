using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloudSuite.Core.Messaging.RabbitMq.Consumers
{
    public class AddressCoreConsumer : BackgroundService
    {
        private readonly RabbitMqSettings _settings;
        private readonly ILogger<AddressCoreConsumer> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public AddressCoreConsumer(IOptions<RabbitMqSettings> options, ILogger<AddressCoreConsumer> logger)
        {
            _settings = options.Value;
            _logger = logger;

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
            _channel.QueueDeclare(queue: _settings.RabbitMqConfiguration.Queues["Address"], durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: _settings.RabbitMqConfiguration.Queues["Address"], exchange: _settings.RabbitMqConfiguration.ExchangeName, routingKey: _settings.RabbitMqConfiguration.RoutingKeys["Address"]);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                try
                {
                    await ProcessMessageAsync(message);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message");

                    _channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            _channel.BasicConsume(queue: _settings.RabbitMqConfiguration.Queues["Address"], autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        private async Task ProcessMessageAsync(string message)
        {
            _logger.LogInformation($"Received message: {message}");

            await Task.Delay(500); // Simulate some asynchronous processing
            _logger.LogInformation($"Processed message: {message}");
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }
    }
}
