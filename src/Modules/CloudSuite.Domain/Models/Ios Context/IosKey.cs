using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Ios_Context
{
    public class IosKey : Entity, IAggregateRoot
    {
        public IosKey(string? iosAccount, string? iosGeneric, string? iosService, int? iosType)
        {
            IosAccount = iosAccount;
            IosGeneric = iosGeneric;
            IosService = iosService;
            IosType = iosType;
        }

        public string? IosAccount { get; private set; }

        public string? IosGeneric { get; private set; }

        public string? IosService { get; private set; }

        public int? IosType { get; private set; }

        public static implicit operator IosKey(Lazy<IosKey> v)
        {
            throw new NotImplementedException();
        }
    }
}
