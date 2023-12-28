using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class StateEFCoreMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("Id");

            builder.Property(h => h.StateName)
                .HasColumnName("StateName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.UF)
                .HasColumnName("UF")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            // Relacionamento com Country
            builder.HasOne(s => s.Country)
                .WithMany(s => s.States)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}