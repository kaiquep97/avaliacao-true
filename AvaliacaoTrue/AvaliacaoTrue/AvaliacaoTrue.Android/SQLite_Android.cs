using System.IO;
using AvaliacaoTrue.Droid;
using AvaliacaoTrue.Interfaces;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace AvaliacaoTrue.Droid
{
    public class SQLite_Android : ISQLite
    {
        private const string nomeDB = "DB_TrueStudio.db3";
        public SQLiteConnection GetConnection()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, nomeDB);
            return new SQLiteConnection(caminhoDB);
        }
    }
}