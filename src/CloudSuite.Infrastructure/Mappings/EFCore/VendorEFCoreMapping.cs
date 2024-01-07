using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class VendorEFCoreMapping : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Id)
                .HasColumnName("Id");

            builder.Property(j => j.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(j => j.Slug)
                .HasColumnName("Slug")
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(j => j.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(p => p.Cnpj)
                            .Property(p => p.CnpjNumber).HasColumnName("CNPJNumber").HasMaxLength(11).IsRequired();

            builder.HasOne(v => v.Email)
                .WithMany()
                .HasForeignKey(v => v.EmailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.CreatedOn);
            builder.Property(v => v.LatestUpdatedOn);
            builder.Property(v => v.IsActive);
            builder.Property(v => v.IsDeleted);

            // Relacionamento com User
            builder.HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}