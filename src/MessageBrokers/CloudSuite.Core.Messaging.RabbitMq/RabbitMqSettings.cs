using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Core.Messaging.RabbitMq
{
    public class RabbitMqSettings
    {
        public LoggingSettings Logging { get; set; }

        public RabbitMqConfiguration RabbitMqConfiguration { get; set; }

        public string QueueName_Address_Core => RabbitMqConfiguration.Queues["Address"];
        public string RoutingKey_Address_Core => RabbitMqConfiguration.RoutingKeys["Address"];
        public string ExchangeName => RabbitMqConfiguration.ExchangeName;
    }
}
