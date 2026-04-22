using SQLite;
using System;
using System.Linq;
using MoonScrapper.Models;


namespace MoonScrapper.Data
{
    public class DataManager
    {
        private SQLiteConnection _db;

        public DataManager(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<GameSave>();
        }

        public void SaveGame(GameSave save)
        {
            _db.Insert(save);
        }

        public GameSave LoadGame(int id)
        {
            return _db.Find<GameSave>(id);
        }
    }
}