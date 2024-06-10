using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class CompanyEFCoreMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.OwnsOne(p => p.Cnpj)
                            .Property(p => p.CnpjNumber).HasColumnName("cnpj_number").HasMaxLength(11).IsRequired();

            builder.Property(c => c.FantasyName)
                .HasColumnName("fantasy_name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.RegisterName)
                .HasColumnName("register_name")
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}