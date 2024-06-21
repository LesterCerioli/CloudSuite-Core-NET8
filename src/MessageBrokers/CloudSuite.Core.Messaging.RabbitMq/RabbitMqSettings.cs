using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Core.Messaging.RabbitMq
{
    public class RabbitMqSettings
    {
        public string? HostName { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? VirtualHost { get; set; }

        public string? ExchangeName { get; set; }

        public string? QueueNameAddressCore { get; set; }

        public string? RoutingKeyCustomerCore { get; set; }

        
        public string? QueueNameCustomerContext { get; set; }

        public string? QueueName_Company_Core { get; set; }

        public string? QueueName_City_Core { get; set; }
    }
}
