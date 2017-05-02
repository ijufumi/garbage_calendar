using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using garbage_calendar.Logic;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace garbage_calendar.Repository
{
    public class GarbageDayRepository : IGarbageDayRepository
    {
        private IMobileServiceSyncTable<GarbageDay> _garbageDayTable;

        private MobileServiceClient _client;
        public GarbageDayRepository(
            //MobileServiceClient client
        )
        {
            Debug.WriteLine("GarbageDayRepository() START");
            _client = MobileServiceClientFactory.create();
            // _garbageDayTable = client.GetSyncTable<GarbageDay>();
            Debug.WriteLine("GarbageDayRepository() END");
        }

        public Task<IEnumerable<GarbageDay>> GetAllAsync()
        {
            return _garbageDayTable.CreateQuery().ToEnumerableAsync();
        }

        public async Task SyncAsync()
        {
            await _garbageDayTable.PullAsync("allRecord", _garbageDayTable.CreateQuery());
        }
    }
}