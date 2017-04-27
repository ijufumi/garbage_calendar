using System;
using System.Diagnostics;
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

        public DataSynchronizer(
            //MobileServiceClient client
        )
        {
            Debug.WriteLine("DataSynchronizer() START");
            //_client = client;
            //_garbageDayTable = _client.GetSyncTable<GarbageDay>();
            Debug.WriteLine("DataSynchronizer() END");
        }

        public async Task SyncAsync()
        {
            await _garbageDayTable.PullAsync("allRecord", _garbageDayTable.CreateQuery());
        }
    }
}