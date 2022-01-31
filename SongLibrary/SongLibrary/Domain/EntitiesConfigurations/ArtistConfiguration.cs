using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongLibrary.Domain.Entities;

namespace SongLibrary.Domain.EntitiesConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<ArtistEntity>
    {
        public void Configure(EntityTypeBuilder<ArtistEntity> builder)
        {
            builder.ToTable("Artist").HasKey(a => a.ArtistId);
            builder.Property(a => a.ArtistId).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(120);
            builder.Property(a => a.DateOfBirth).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(20);
            builder.Property(a => a.Email).HasMaxLength(20);
            builder.Property(a => a.InstagramURL).HasMaxLength(1000);

            builder.HasMany(a => a.Songs)
                .WithMany(s => s.Artists)
                .UsingEntity<Dictionary<string, object>>(
                "ArtistSong",
                j => j
                .HasOne<SongEntity>()
                .WithMany()
                .HasForeignKey("SondId"),
                j => j
                .HasOne<ArtistEntity>()
                .WithMany()
                .HasForeignKey("ArtistId"));
        }
    }
}
