using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TrueStudio.Droid;
using TrueStudio.Interfaces;

[assembly:Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace TrueStudio.Droid
{
    public class SQLite_Android : ISQLite
    {
        private const string nomeDB = "Credenciamento.db3";

        public SQLiteConnection GetConnection()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, nomeDB);
            return new SQLiteConnection(caminhoDB);
        }
    }
}