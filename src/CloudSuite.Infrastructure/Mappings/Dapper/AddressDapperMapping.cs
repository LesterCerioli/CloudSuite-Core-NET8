using CloudSuite.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class AddressDapperMapping : DommelEntityMap<Address>
    {
        public AddressDapperMapping()
        {
            ToTable("Addresses");
            Map(p => p.Id).IsIdentity();
            Map(p => p.ContactName).ToColumn("ContactName").Ignore();
            Map(p => p.AddressLine1).ToColumn("AddressLine").Ignore();
        }
        
    }
}