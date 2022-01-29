using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLibrary.Domain.Entities;

namespace SongLibrary.Domain.EntitiesConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.ToTable("Genre").HasKey(g => g.GenreId);
            builder.Property(g => g.GenreId).ValueGeneratedOnAdd();
            builder.Property(g => g.Title).IsRequired().HasMaxLength(50);
        }
    }
}
