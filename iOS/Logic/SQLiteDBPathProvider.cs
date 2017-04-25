using garbage_calendar.Logic;

namespace garbage_calendar.iOS.Logic
{
    public class SQLiteDBPathProvider : ISQLiteDBPathProvider
    {
        public string GetPath()
        {
            SQLitePCL.Batteries.Init();
            return "localstore.db";
        }
    }
}