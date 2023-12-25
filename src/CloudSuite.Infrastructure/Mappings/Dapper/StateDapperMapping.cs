namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class StateDapperMapping : DommelEntityMap<State>
    {
        public StateDapperMapping()
        {
            ToTable("States");
            Map(p => p.Id).IsKey();
            Map(p => p.StateName).ToColumn("StateName");
            Map(p => p.UF).ToColumn("UF");
            Map(p => p.CountryId).ToColumn("CountryId");

            // Map other fields as needed

            // Map relationship with Country
            References(p => p.Country).Column("CountryId").Reference();

            // If there are other relationships, map them as needed
        }
        
    }
}