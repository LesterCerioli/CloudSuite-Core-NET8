using CloudSuite.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Ios_Context
{
    public partial class MsalCacheKeys
    {
        internal static readonly bool CacheKeyDelimiter;

        public IOSCredentialAttrTypeEnum CredentialAttrTypeEnum { get; private set; }
    }
}
