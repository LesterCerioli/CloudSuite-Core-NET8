using CloudSuite.Domain.Models.Ios_Context;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class CacheKey : Entity, IAggregateRoot
    {
        public string Value { get; private set; }

        private string BuildCacheKey(string homeAccountId, string environment, string keyDescriptor, string clientId, string tenantId, string scopes, string[] additionalKeys)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(homeAccountId ?? "");
            stringBuilder.Append(MsalCacheKeys.CacheKeyDelimiter);
            stringBuilder.Append(environment);
            stringBuilder.Append(MsalCacheKeys.CacheKeyDelimiter);
            stringBuilder.Append(keyDescriptor);
            stringBuilder.Append(MsalCacheKeys.CacheKeyDelimiter);
            stringBuilder.Append(clientId);
            stringBuilder.Append(MsalCacheKeys.CacheKeyDelimiter);
            stringBuilder.Append(tenantId ?? "");
            stringBuilder.Append(MsalCacheKeys.CacheKeyDelimiter);
            stringBuilder.Append(scopes ?? "");

            foreach (var additionalKey in additionalKeys ?? Enumerable.Empty<string>())
            {
                stringBuilder.Append(MsalCacheKeys.CacheKeyDelimiter);
                stringBuilder.Append(additionalKey);
            }

            return stringBuilder.ToString().ToLowerInvariant();
        }
    }
}
