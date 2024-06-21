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

        public string? RoutingKeyCustomerCore { get; set; }

        public string? RountingKey_City_Core { get; set; }

        public string? RoutingKey_Address_Core { get; set; }

        public string? RoutingKey_Company_Core { get; set; }

        public string? RoutingKey_Country_Core { get; set; }

        public string? RountingKey_District_Core { get; set; }

        public string? RountingKey_State_Core { get; set; }

        public string? RountingKey_User_Core { get; set; }

        public string? QueueName_Address_Core { get; set; }

        public string? QueueNameCustomerContext { get; set; }

        public string? QueueName_Company_Core { get; set; }

        public string? QueueName_City_Core { get; set; }

        public string? QueryName_Company_Core { get; set; }

        public string? QueueName_Country_Core { get; set; }

        public string? QueueName_District_Core { get; set; }

        public string? QueueName_State_Core { get; set; }

        public string? QueueName_User_Core { get; set; }
    }
}
