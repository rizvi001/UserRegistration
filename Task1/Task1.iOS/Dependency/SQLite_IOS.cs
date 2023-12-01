using System;
using System.IO;
using System.Runtime.CompilerServices;
using SQLite;
using Task1.Interface;
using Task1.iOS.Dependency;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_IOS))]
namespace Task1.iOS.Dependency
{
    public class SQLite_IOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "myDataBase.sqlite";
            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(dbPath,"..","Library");
            var path = Path.Combine(libraryPath, dbName);
            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}

