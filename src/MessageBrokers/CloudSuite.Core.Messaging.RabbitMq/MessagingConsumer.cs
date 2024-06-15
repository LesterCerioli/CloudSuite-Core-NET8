using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Core.Messaging.RabbitMq
{
    public class MessagingConsumer
    {
        private readonly MessagingConfiguration _config;

        public MessagingConsumer(MessagingConfiguration config)
        {
            _config = config;
        }

        public void Start(Action<string>)
    }
}
