using CloudSuite.Domain.Models;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class CityDapperMapping : DommelEntityMap<City>
    {
        public CityDapperMapping()
        {
            ToTable("Cities");
            Map(p => p.Id).IsIdentity();
            Map(p => p.CityName).ToColumn("CityName").Ignore();

        }
        
    }
}