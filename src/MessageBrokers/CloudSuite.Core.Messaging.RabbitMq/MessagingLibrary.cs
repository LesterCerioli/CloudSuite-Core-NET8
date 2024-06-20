using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Core.Messaging.RabbitMq
{
    public class MessagingLibrary
    {
        private readonly MessagingConfiguration _config;

        public MessagingLibrary(MessagingConfiguration config)
        {
            _config = config;
        }

        public void Publish(string message)
        {
            var factory = new ConnectionFactory() { HostName = _config.Hostname };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _config.QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: _config.QueueName,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($" [x] Sent {message}");
            }
        }
    }
}
