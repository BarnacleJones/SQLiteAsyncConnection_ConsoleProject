﻿using SQLiteConsoleApp. DiscogsInsight.Database.Contract;
using SQLite;

namespace SQLiteConsoleApp.DiscogsInsight.Database.Entities
{
    public class DiscogsGenreTags : IDatabaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? DiscogsTag { get; set; }
    }
}
