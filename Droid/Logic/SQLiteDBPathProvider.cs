using System;
using System.IO;
using garbage_calendar.Logic;

namespace garbage_calendar.Droid.Logic
{
    public class SQLiteDBPathProvider : ISQLiteDBPathProvider
    {
        public string GetPath()
        {
            var path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "localstore.db");

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}