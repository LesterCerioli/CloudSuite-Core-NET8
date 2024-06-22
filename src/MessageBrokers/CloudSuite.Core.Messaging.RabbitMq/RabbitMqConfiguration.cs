using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Core.Messaging.RabbitMq
{
    public class RabbitMqConfiguration
    {
        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string VirtualHost { get; set; }

        public string ExchangeName { get; set; }

        public Dictionary<string, string> Queues { get; set; }

        public Dictionary<string, string> RoutingKeys { get; set; }

    }
}
