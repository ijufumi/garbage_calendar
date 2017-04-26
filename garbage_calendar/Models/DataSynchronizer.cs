using System.Threading.Tasks;
using garbage_calendar.Repository;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace garbage_calendar.Logic
{
    public class DataSynchronizer : IDataSynchronizer
    {
        private MobileServiceClient _client;

        private readonly IMobileServiceSyncTable<GarbageDay> _garbageDayTable;

        public DataSynchronizer(MobileServiceClient client)
        {
            _client = client;
            _garbageDayTable = _client.GetSyncTable<GarbageDay>();
        }

        public async Task SyncAsync()
        {
            await _garbageDayTable.PullAsync("allRecord", _garbageDayTable.CreateQuery());
        }
    }
}