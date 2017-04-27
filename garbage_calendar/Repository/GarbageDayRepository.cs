using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace garbage_calendar.Repository
{
    public class GarbageDayRepository : IGarbageDayRepository
    {
        private IMobileServiceSyncTable<GarbageDay> GarbageDayTable { get; }

        public GarbageDayRepository(
            //MobileServiceClient client
        )
        {
            Debug.WriteLine("GarbageDayRepository() START");
            //GarbageDayTable = client.GetSyncTable<GarbageDay>();
            Debug.WriteLine("GarbageDayRepository() END");
        }

        public Task<IEnumerable<GarbageDay>> GetAllAsync()
        {
            return GarbageDayTable.CreateQuery().ToEnumerableAsync();
        }
    }
}