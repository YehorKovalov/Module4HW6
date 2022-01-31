using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SongLibrary.Domain;
using SongLibrary.Domain.Entities;
using SongLibrary.Helpers;
using SongLibrary.Services.Abstractions;

namespace SongLibrary.Services
{
    public class SongLibraryServices : BaseDataService, ISongLibraryServices
    {
        public SongLibraryServices(SongLibraryDbContext db)
            : base(db)
        {
        }

        public async Task<IEnumerable<SongEntity>> GetSongsWithGenresAndArtistOrNull()
        {
            return await ExecuteSafely(() => Db.Songs
            .Include(s => s.Genre)
            .Include(s => s.Artists)
            .Where(s => s.Genre != null && s.Artists != null)
            .ToListAsync());
        }

        public async Task DisplaySongsAmountInEveryGenres()
        {
            if (!(await Db.Genres.AnyAsync()))
            {
                Console.WriteLine("There is not any genre");
            }

            var result = await ExecuteSafely(() => Db.Genres.Select(g => new
            {
                Genre = g.Title,
                SongsAmount = g.Songs.Count
            }).ToListAsync());

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Genre}: {item.SongsAmount}");
            }
        }

        public async Task<IEnumerable<SongEntity>> GetSongsThatOlderThanYoungestArtistOrNull()
        {
            var artistsAny = await Db.Artists.AnyAsync();
            var songsAny = await Db.Songs.AnyAsync();
            if (!artistsAny || !songsAny)
            {
                return null;
            }

            var youngestArtistDateOfBirth = await ExecuteSafely(() => Db.Artists.MaxAsync(a => a.DateOfBirth));

            return await ExecuteSafely(() => Db.Songs
                .Where(s => s.ReleasedDate < youngestArtistDateOfBirth)
                .ToListAsync());
        }
    }
}
