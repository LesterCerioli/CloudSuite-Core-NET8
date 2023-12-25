namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class DistrictDapperMapping : DommelEntityMap<District>
    {
        public DistrictDapperMapping()
        {
            ToTable("Districts");
            Map(p => p.Id).IsKey();
            Map(p => p.Name).ToColumn("Name");
            Map(p => p.Type).ToColumn("Type");
            Map(p => p.Location).ToColumn("Location");
            Map(p => p.CityId).ToColumn("CityId");

            
            // Mapping a relationship
            References(p => p.City).Column("CityId").Reference();

            
        }
        
    }
}