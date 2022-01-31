using System.Text;
using System.Threading.Tasks;
using SongLibrary.Helpers;
using SongLibrary.Services.Abstractions;

namespace SongLibrary
{
    public class Application
    {
        private readonly TestEntitiesSeeder _seeder;
        private readonly ISongLibraryServices _libServices;

        public Application(
            TestEntitiesSeeder seeder,
            ISongLibraryServices libraryServices)
        {
            _seeder = seeder;
            _libServices = libraryServices;
        }

        public async Task Run()
        {
            await _seeder.SeedAll();
            var task1Result = await _libServices.GetSongsWithGenresAndArtistOrNull();
            await _libServices.DisplaySongsAmountInEveryGenres();
            var task3Result = await _libServices.GetSongsThatOlderThanYoungestArtistOrNull();
        }
    }
}
