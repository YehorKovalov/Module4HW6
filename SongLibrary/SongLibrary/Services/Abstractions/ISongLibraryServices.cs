using System.Collections.Generic;
using System.Threading.Tasks;
using SongLibrary.Domain.Entities;

namespace SongLibrary.Services.Abstractions
{
    public interface ISongLibraryServices
    {
        Task<IEnumerable<SongEntity>> GetSongsThatOlderThanYoungestArtistOrNull();
        Task DisplaySongsAmountInEveryGenres();
        Task<IEnumerable<SongEntity>> GetSongsWithGenresAndArtistOrNull();
    }
}