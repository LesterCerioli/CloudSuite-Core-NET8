using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class DistrictEFCoreMapping : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasColumnName("Type")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(e => e.Location)
                .HasColumnName("Location")
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}