using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.File>
    {
        public void Configure(EntityTypeBuilder<Domain.File> builder)
        {
            builder.ToTable("Files");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Path)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(u => u.Album)
                .WithMany(u => u.Files)
                .HasForeignKey(u => u.AlbumId);
        }
    }
}
