using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SongLibrary.Domain;
using SongLibrary.Domain.Entities;

namespace SongLibrary.Helpers
{
    public class TestEntitiesSeeder
    {
        private const int SongsAmount = 8;
        private const int ArtistAmount = 5;
        private const int GenreAmount = 5;
        private readonly SongLibraryDbContext _db;

        public TestEntitiesSeeder(SongLibraryDbContext db) => _db = db;

        public async Task SeedAll()
        {
            await SeedGenre();
            await SeedSongsArtists();
        }

        public async Task SeedGenre()
        {
            var genres = new List<GenreEntity>();
            genres.Add(new GenreEntity { Title = "Rock" });
            genres.Add(new GenreEntity { Title = "Jazz" });
            genres.Add(new GenreEntity { Title = "Pop music" });
            genres.Add(new GenreEntity { Title = "Blues" });
            genres.Add(new GenreEntity { Title = "Heavy metal" });
            await _db.Genres.AddRangeAsync(genres);
            await _db.SaveChangesAsync();
        }

        public async Task SeedSongsArtists()
        {
            var songs = GetSongs();
            SeedSongsWithArtists(ref songs);

            await _db.Songs.AddRangeAsync(songs);
            await _db.SaveChangesAsync();
        }

        private List<SongEntity> GetSongs()
        {
            var songs = new List<SongEntity>();
            for (int i = 1; i <= SongsAmount; i++)
            {
                songs.Add(new SongEntity
                {
                    Duration = GetRandomDuration(),
                    GenreId = GetRandomGenreId(),
                    Title = $"Song{i}",
                    ReleasedDate = GetRandomDate()
                });
            }

            return songs;
        }

        private List<ArtistEntity> GetArtists()
        {
            var artists = new List<ArtistEntity>();

            for (int i = 1; i <= ArtistAmount; i++)
            {
                artists.Add(new ArtistEntity
                {
                    Name = $"Artist{i}",
                    DateOfBirth = GetRandomDate(),
                    Email = $"Email{i}",
                    InstagramURL = $"instagram{i}",
                    Phone = $"PhoneNumber{i}"
                });
            }

            return artists;
        }

        private DateTimeOffset GetRandomDate()
        {
            var rand = new Random();
            var year = rand.Next(1900, 2000);
            var month = rand.Next(1, 12);
            var day = rand.Next(1, 28);
            var date = new DateTime(year, month, day);
            return new DateTimeOffset(date);
        }

        private TimeSpan GetRandomDuration()
        {
            var rand = new Random();
            var minutes = rand.Next(0, 60);
            var seconds = rand.Next(0, 60);
            return new TimeSpan(0, minutes, seconds);
        }

        private int GetRandomGenreId()
        {
            return new Random().Next(1, GenreAmount + 1);
        }

        private ArtistEntity GetRandomArtistFromList()
        {
            var artists = GetArtists();
            var randomArtistIndex = new Random().Next(ArtistAmount);
            return artists[randomArtistIndex];
        }

        private void SeedSongsWithArtists(ref List<SongEntity> songs)
        {
            foreach (var song in songs)
            {
                var artist = GetRandomArtistFromList();
                song.Artists.Add(artist);
            }
        }
    }
}
