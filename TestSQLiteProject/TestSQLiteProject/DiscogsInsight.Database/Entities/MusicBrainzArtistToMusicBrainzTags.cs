using SQLiteConsoleApp.DiscogsInsight.Database.Contract;
using SQLite;

namespace SQLiteConsoleApp.DiscogsInsight.Database.Entities
{
    public class MusicBrainzArtistToMusicBrainzTags : IDatabaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }        
        public int TagId {  get; set; }
        public string? MusicBrainzArtistId { get; set;}
    }
}
