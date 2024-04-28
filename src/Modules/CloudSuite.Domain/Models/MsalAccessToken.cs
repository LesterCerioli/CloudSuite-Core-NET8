using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class MsalAccessToken : Entity, IAggregateRoot
    {
        public MsalAccessToken(string? environment, string? clientId, string? secret, string? rawClientInfo, string? homeAccountId, string? tenantId, string? keyId, string tokenType, HashSet<string> scopeSet, string? scopeString, DateTimeOffset? cachedAt, DateTimeOffset? expiresOn, DateTimeOffset? extendedExpiresOn, DateTimeOffset? refreshOn, string? oboCacheKey, bool? isExtendedLifeTimeToken)
        {
            Environment = environment;
            ClientId = clientId;
            Secret = secret;
            RawClientInfo = rawClientInfo;
            HomeAccountId = homeAccountId;
            TenantId = tenantId;
            KeyId = keyId;
            TokenType = tokenType;
            ScopeSet = scopeSet;
            ScopeString = scopeString;
            CachedAt = DateTime.Now;
            ExpiresOn = DateTime.Now;
            ExtendedExpiresOn = DateTime.Now;
            RefreshOn = DateTime.Now;
            OboCacheKey = oboCacheKey;
            IsExtendedLifeTimeToken = isExtendedLifeTimeToken;
        }

        public string? Environment { get; private set; }

        public string? ClientId { get; private set; }

        public string? Secret { get; private set; }

        public string? RawClientInfo { get; private set; }

        public string? HomeAccountId { get; private set; }

        public string? TenantId { get; private set; }

        public string? KeyId { get; private set; }

        public string TokenType { get; private set; }

        public HashSet<string> ScopeSet { get; private set; }

        public string? ScopeString { get; private set; }

        public DateTimeOffset? CachedAt { get; private set; }

        public DateTimeOffset? ExpiresOn { get; private set; }

        public DateTimeOffset? ExtendedExpiresOn { get; private set; }

        public DateTimeOffset? RefreshOn { get; private set; }

        public string? OboCacheKey { get; private set; }

        public bool? IsExtendedLifeTimeToken { get; set; }
    }
}
