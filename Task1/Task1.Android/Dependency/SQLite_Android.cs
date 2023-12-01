using Task1.Interface;
using Xamarin.Forms;
using System.IO;
using Task1.Droid.Dependency;
using SQLite;
[assembly: Dependency(typeof(SQLite_Android))]
namespace Task1.Droid.Dependency
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "mydatabase.sqlite";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}

