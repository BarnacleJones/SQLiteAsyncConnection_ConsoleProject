using SQLiteConsoleApp.DiscogsInsight.Database.Contract;
using SQLiteConsoleApp.DiscogsInsight.Database.Entities;

namespace SQLiteConsoleApp.Database.Services
{
    public class DiscogsInsightDb : IDiscogsInsightDb
    {
        private readonly ISQLiteAsyncConnection _database;

        public DiscogsInsightDb(ISQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<List<T>> GetAllEntitiesAsListAsync<T>() where T : new()
        { 
            return await _database.Table<T>().ToListAsync();
        }

        public async Task Purge()
        {
            try
            {
                await _database.DeleteAllAsync<Artist>();
                await _database.DeleteAllAsync<Release>();
                //intentionally leaving other data. Use PurgeEntireDb for the other
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task PurgeEntireDb()
        {
            try
            {
                await _database.DeleteAllAsync<Artist>();
                await _database.DeleteAllAsync<DiscogsGenreTags>();
                await _database.DeleteAllAsync<DiscogsGenreTagToDiscogsRelease>();
                await _database.DeleteAllAsync<MusicBrainzArtistToMusicBrainzRelease>();
                await _database.DeleteAllAsync<MusicBrainzArtistToMusicBrainzTags>();
                await _database.DeleteAllAsync<MusicBrainzReleaseToCoverImage>();
                await _database.DeleteAllAsync<MusicBrainzTags>();
                await _database.DeleteAllAsync<Release>();
                await _database.DeleteAllAsync<Track>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : IDatabaseEntity, new()
        {
            try
            {
                var entityToDelete = await _database.GetAsync<T>(pk: entity.Id);
                var a = await _database.DeleteAsync(entityToDelete);
                return a;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertAsync<T>(T entity) where T : IDatabaseEntity, new()
        {
            try
            {
                var a = await _database.InsertAsync(entity);
                
                return a;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> UpdateAsync<T>(T entity) where T : IDatabaseEntity, new()
        {
            try
            {
                var a = await _database.UpdateAsync(entity);
                return a;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

