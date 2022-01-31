using System;
using System.Threading.Tasks;
using SongLibrary.Domain;

namespace SongLibrary.Helpers
{
    public abstract class BaseDataService
    {
        private readonly SongLibraryDbContext _db;
        public BaseDataService(SongLibraryDbContext db) => _db = db;

        protected SongLibraryDbContext Db => _db;

        public async Task<T> ExecuteSafely<T>(Func<Task<T>> action)
        {
            await using (var transaction = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await action.Invoke();
                    await transaction.CommitAsync();
                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return default(T);
                }
            }
        }
    }
}
