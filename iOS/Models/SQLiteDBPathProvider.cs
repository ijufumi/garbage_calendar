using System.Diagnostics;
using garbage_calendar.Logic;

namespace garbage_calendar.iOS.Logic
{
    public class SQLiteDBPathProvider : ISQLiteDBPathProvider
    {
        public SQLiteDBPathProvider()
        {
            Debug.WriteLine("SQLiteDBPathProvider() START");
            Debug.WriteLine("SQLiteDBPathProvider() END");
        }

        public string GetPath()
        {
            SQLitePCL.Batteries.Init();
            return "localstore.db";
        }
    }
}