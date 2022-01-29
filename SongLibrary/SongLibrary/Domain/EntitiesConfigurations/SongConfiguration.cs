using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLibrary.Domain.Entities;

namespace SongLibrary.Domain.EntitiesConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<SongEntity>
    {
        public void Configure(EntityTypeBuilder<SongEntity> builder)
        {
            builder.ToTable("Song").HasKey(s => s.SongId);
            builder.Property(s => s.SongId).ValueGeneratedOnAdd();
            builder.Property(s => s.ReleasedDate).IsRequired();
            builder.Property(s => s.Title).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Duration).IsRequired();

            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
