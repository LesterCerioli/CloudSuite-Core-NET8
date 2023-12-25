namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class CountryDapperMapping : DommelEntityMap<Country>
    {
        public CountryDapperMapping()
        {
            ToTable("Countries");
            Map(p => p.Id).IsKey();
            Map(p => p.CountryName).ToColumn("CountryName");
            Map(p => p.Code3).ToColumn("Code");
            Map(p => p.IsBillingEnabled).ToColumn("IsBillingEnabled");
            Map(p => p.IsShippingEnabled).ToColumn("IsShippingEnabled");
            Map(p => p.IsCityEnabled).ToColumn("IsCityEnabled");
            Map(p => p.IsZipCodeEnabled).ToColumn("IsZipCodeEnabled");
            Map(p => p.IsDistrictEnabled).ToColumn("IsDistrictEnabled");
            

            // Mapping for a relationship
            Map(p => p.StateId).ToColumn("StateId");
        }
    }
}