namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class VendorDapperMapping : DommelEntityMap<Vendor>
    {
        public VendorDapperMapping()
        {
            ToTable("Vendors");
            Map(p => p.Id).IsKey();
            Map(p => p.Name).ToColumn("Name");
            Map(p => p.Slug).ToColumn("Slug");
            Map(p => p.Description).ToColumn("Description");
            Map(p => p.Cnpj.CnpjNumber).ToColumn("CNPJNumber");
            Map(p => p.EmailId).ToColumn("EmailId");
            Map(p => p.CreatedOn).ToColumn("CreatedOn");
            Map(p => p.LatestUpdatedOn).ToColumn("LatestUpdatedOn");
            Map(p => p.IsActive).ToColumn("IsActive");
            Map(p => p.IsDeleted).ToColumn("IsDeleted");

            // Map other fields as needed

            // Map relationship with Email
            References(p => p.Email).Column("EmailId").Reference();

            // Map relationship with User
            References(p => p.User).Column("UserId").Reference();

            // If there are other relationships, map them as needed
        }
        
    }
}