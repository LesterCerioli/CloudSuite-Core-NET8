using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class MediaEFCoreMapping : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("Id");

            builder.Property(g => g.Caption)
                .HasColumnName("Caption")
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(g => g.FileSize)
                .HasColumnName("FileSize")
                .IsRequired();

            builder.Property(g => g.FileName)
                .HasColumnName("FileName")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.MediaType)
                .HasColumnName("MediaType")
                .IsRequired()
                .HasColumnType("int"); // Tipo de dado para a enumeração MediaType
        }
    }
}