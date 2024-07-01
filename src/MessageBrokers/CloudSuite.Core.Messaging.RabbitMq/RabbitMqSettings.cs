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

        public string QueueName_City_Core => RabbitMqConfiguration.Queues["City"];

        public string RoutingKey_City_Core => RabbitMqConfiguration.RoutingKeys["City"];

        public string QueueName_Company_Core => RabbitMqConfiguration.Queues["Company"];

        public string RoutingKey_Company_Core => RabbitMqConfiguration.RoutingKeys["Company"];

        public string QueueName_Country_Core => RabbitMqConfiguration.Queues["Country"];

        public string RoutingKey_Country_Core => RabbitMqConfiguration.RoutingKeys["Country"];

        public string QueueName_District_Core => RabbitMqConfiguration.Queues["District"];

        public string RoutingKey_District_Core => RabbitMqConfiguration.RoutingKeys["District"];

        public string QueueName_Media_Core => RabbitMqConfiguration.Queues["Media"];

        public string RoutingKey_Media_Core => RabbitMqConfiguration.RoutingKeys["Media"];

        public string QueueName_State_Core => RabbitMqConfiguration.Queues["State"];

        public string RoutingKey_State_Core => RabbitMqConfiguration.RoutingKeys["State"];

        public string QueueName_User_Core => RabbitMqConfiguration.Queues["User"];

        public string RoutingKey_User_Core => RabbitMqConfiguration.RoutingKeys["User"];

        public string QueueName_Vendor_Core => RabbitMqConfiguration.Queues["Vendor"];

        public string RoutingKey_Vendor_Core => RabbitMqConfiguration.RoutingKeys["Vendor"];

        public string ExchangeName => RabbitMqConfiguration.ExchangeName;
    }
}
