﻿using SQLite;
using SQLiteConsoleApp.DiscogsInsight.Database.Entities;


namespace SQLiteConsoleApp.DiscogsInsight.Database.Services
{
    /// <summary>
    /// Created a connection adapter to abstract the DiscogsInsightDb class for testing.
    /// I had to do that as the SQLiteAsyncConnection was a static service and was causing headaches mocking
    /// But there has to be an implementation like this for it all to work
    /// </summary>
    public class SQLiteAsyncConnectionAdapter : Contract.ISQLiteAsyncConnection
    {
        SQLiteAsyncConnection _connection;

        public SQLiteAsyncConnectionAdapter()
        {           
            _connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            try
            {
                var a = Constants.DatabasePath;//handy for debugging figuring out where the db is

                await _connection.CreateTableAsync<Artist>();
                await _connection.CreateTableAsync<Release>();
                await _connection.CreateTableAsync<Track>();
                await _connection.CreateTableAsync<MusicBrainzTags>();
                await _connection.CreateTableAsync<MusicBrainzArtistToMusicBrainzTags>();
                await _connection.CreateTableAsync<MusicBrainzArtistToMusicBrainzRelease>();
                await _connection.CreateTableAsync<MusicBrainzReleaseToCoverImage>();
                await _connection.CreateTableAsync<DiscogsGenreTagToDiscogsRelease>();
                await _connection.CreateTableAsync<DiscogsGenreTags>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
                throw;
            }
        }

        public Task CreateTableAsync<T>() where T : new()
        {
            return _connection.CreateTableAsync<T>();
        }

        public Task<int> DeleteAllAsync<T>() where T : new()
        {
            return _connection.DeleteAllAsync<T>();
        }

        public Task<int> DeleteAsync(object obj)
        {
            return _connection.DeleteAsync(obj);
        }

        public Task<int> ExecuteAsync(string query, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync<T>(object pk) where T : new()
        {
            return _connection.FindAsync<T>(pk);
        }

        public Task<T> GetAsync<T>(object pk) where T : new()
        {
            return _connection.GetAsync<T>(pk);
        }

        public Task<int> InsertAsync(object obj)
        {
            return _connection.InsertAsync(obj);
        }

        public Task<List<T>> QueryAsync<T>(string query, params object[] args) where T : new()
        {
            return _connection.QueryAsync<T>(query, args);
        }

        public AsyncTableQuery<T> Table<T>() where T : new()
        {
            return _connection.Table<T>();
        }

        public Task<int> UpdateAsync(object obj)
        {
            return _connection.UpdateAsync(obj);
        }

        public Task<T> ExecuteScalarAsync<T>(string query, params object[] args)
        {
            return _connection.ExecuteScalarAsync<T>(query, args);
        }
    }
}
