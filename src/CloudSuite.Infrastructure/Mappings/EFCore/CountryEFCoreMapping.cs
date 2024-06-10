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
                .HasColumnName("code")
                .HasColumnType("varchar(450)")
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(d => d.IsBillingEnabled)
                .HasColumnName("is_billing_enabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsShippingEnabled)
                .HasColumnName("is_shipping_enabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsCityEnabled)
                .HasColumnName("is_city_enabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsZipCodeEnabled)
                .HasColumnName("is_zip_code_enabled")
                .HasColumnType("bit");
            builder.Property(d => d.IsDistrictEnabled)
                .HasColumnName("is_dDistrict_enabled")
                .HasColumnType("bit");

            // Relacionamento com State
            builder.HasOne(p => p.State)
                .WithMany()
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}