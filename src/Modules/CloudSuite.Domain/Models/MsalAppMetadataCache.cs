using CloudSuite.Domain.Models.Ios_Context;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class MsalAppMetadataCache : Entity, IAggregateRoot
    {

        private readonly List<IosKey> _iosKyes;


        public MsalAppMetadataCache(string clientId, string environment, string familyId, string cacheKey, IosKey iOSCacheKey)
        {
            ClientId = clientId;
            Environment = environment;
            FamilyId = familyId;
            CacheKey = cacheKey;
            IOSCacheKey = iOSCacheKey;
            _iosKyes = new List<IosKey>();
        }

        public string ClientId { get; private set; }

        public string Environment { get; private set; }

        public string FamilyId { get; private set; }

        public string CacheKey { get; private set; }


        public IosKey IOSCacheKey { get; private set; }
               

        public IReadOnlyCollection<IosKey> Ioskeys => _iosKyes.AsReadOnly();

        private void Initialize()
        {
            CacheKey = CreateCacheKey();
            IOSCacheKey = new Lazy<IosKey>();
        }

        private string CreateCacheKey()
        {
            throw new NotImplementedException();
        }

        //private string CreateCacheKey()
        //{
        //return $"{StorageJsonKeys.AppMetadata}{MsalCacheKeys.CacheKeyDelimiter}{Environment}{MsalCacheKeys.CacheKeyDelimiter}{ClientId}".ToLowerInvariant();
        //}

        //private IosKey CreateiOSKey()
        //{
        //string iOSService = $"{StorageJsonValues.AppMetadata}{MsalCacheKeys.CacheKeyDelimiter}{ClientId}".ToLowerInvariant();
        //string iOSGeneric = "1";
        //string iOSAccount = Environment.ToLowerInvariant();
        //int iOSType = (int)MsalCacheKeys.iOSCredentialAttrType.AppMetadata;
        //return new IosKey(iOSAccount, iOSService, iOSGeneric, iOSType);
        //}

        //public override bool Equals(object obj)
        //{
        //return Equals(obj as MsalAppMetadataCacheItem);
        //}

        //public bool Equals(MsalAppMetadataCacheItem other)
        //{
        //if (other == null) return false;
        //return Id.Equals(other.Id);
        //}

        //public override int GetHashCode()
        //{
        //return HashCode.Combine(Id);
        //}
    }
}
