namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class CompanyDapperMapping : DommelEntityMap<Company>
    {
        public CompanyDapperMapping()
        {
            ToTable("Companies");
            Map(p => p.Id).IsIdentity();
            Map(p => p.Cnpj).ToColumn("Cnpj").Ignore();
            Map(p => p.FantasyName).ToColumn("FantasyName").Ignore();
            Map(p => p.RegisterName).ToColumn("Registername").Ignore();

        }
        
    }
}