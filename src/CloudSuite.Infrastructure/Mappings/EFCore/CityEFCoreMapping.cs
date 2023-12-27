using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class CityEFCoreMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id");

            builder.Property(b => b.CityName)
                .HasColumnName("CityName")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne(p => p.State)
                .WithMany()
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}