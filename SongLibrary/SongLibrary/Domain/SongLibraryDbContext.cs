using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SongLibrary.Domain.Entities;
using SongLibrary.Domain.EntitiesConfigurations;

namespace SongLibrary.Domain
{
    public class SongLibraryDbContext : DbContext
    {
        public SongLibraryDbContext(DbContextOptions<SongLibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<ArtistEntity> Artists { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<SongEntity> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
        }
    }
}
