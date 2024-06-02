using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class CountryEFCoreMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("id");

            builder.Property(d => d.CountryName)
                .HasColumnName("country_name")
                .IsRequired()
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(d => d.Code3)
                .HasColumnName("Code")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450);

            builder.Property(d => d.IsBillingEnabled)
                .HasColumnName("IsBillingEnabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsShippingEnabled)
                .HasColumnName("IsShippingEnabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsCityEnabled)
                .HasColumnName("IsCityEnabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsZipCodeEnabled)
                .HasColumnName("IsZipCodeEnabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsDistrictEnabled)
                .HasColumnName("IsDistrictEnabled")
                .HasColumnType("bit");

            // Relacionamento com State
            builder.HasMany(c => c.States)
                .WithOne(s => s.Country)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}