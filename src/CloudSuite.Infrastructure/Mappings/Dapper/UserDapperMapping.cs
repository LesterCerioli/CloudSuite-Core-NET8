using CloudSuite.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class UserDapperMapping : DommelEntityMap<User>
    {
        public UserDapperMapping()
        {
            ToTable("Users");
            Map(p => p.Id).IsKey();
            Map(p => p.FullName).ToColumn("FullName");
            Map(p => p.IsDeleted).ToColumn("IsDeleted");
            Map(p => p.Cpf.CpfNumber).ToColumn("CPFNumber");
            Map(p => p.Telephone.TelephoneRegion).ToColumn("TelephoneRegion");
            Map(p => p.Telephone.TelephoneNumber).ToColumn("TelephoneNumber");
            Map(p => p.CreatedOn).ToColumn("CreatedOn");
            Map(p => p.LatestUpdatedOn).ToColumn("LatestUpdatedOn");
            Map(p => p.EmailId).ToColumn("EmailId");
            Map(p => p.RefreshTokenHash).ToColumn("RefreshTokenHash");

            
        }
        
    }
}