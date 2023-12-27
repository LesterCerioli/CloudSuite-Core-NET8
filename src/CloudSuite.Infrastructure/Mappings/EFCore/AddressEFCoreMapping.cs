using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class AddressEFCoreMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id");

            builder.Property(a => a.ContactName)
                .HasColumnName("ContactName")
                .HasColumnType("varchar(50)");

            builder.Property(a => a.AddressLine1)
                .HasColumnName("AddressLine")
                .HasColumnType("varchar(450)");

            builder.HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.District)
                .WithMany()
                .HasForeignKey(p => p.DistrictId)
                .OnDelete(DeleteBehavior.Restrict); // Pode ajustar conforme necessário

            
            

        }
    }
}