using System.Threading.Tasks;

namespace garbage_calendar.Logic
{
    public interface IDataSynchronizer
    {
        Task SyncAsync();
    }
}