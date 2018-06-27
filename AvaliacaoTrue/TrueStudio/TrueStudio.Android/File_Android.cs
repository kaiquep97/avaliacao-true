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
using TrueStudio.Droid;
using TrueStudio.Interfaces;

[assembly:Xamarin.Forms.Dependency(typeof(File_Android))]
namespace TrueStudio.Droid
{
    public class File_Android:IFile
    {
        public bool SaveFile(string content, string nameFile = "relatorio.csv")
        {
            //var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, nameFile);
            var path = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).Path, nameFile);

            try
            {
                File.WriteAllText(path, content, Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}