using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using garbage_calendar.Repository;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Prism.Mvvm;

namespace garbage_calendar.Logic
{
    public class GarbageDayService : BindableBase
    {
        public ObservableCollection<GarbageDay> GarbageDays { get; } = new ObservableCollection<GarbageDay>();

        private readonly ISQLiteDBPathProvider _sqLiteDbPathProvider;
        private readonly MobileServiceClient _client;
        private readonly IGarbageDayRepository _garbageDayRepository;

        public GarbageDayService(
            ISQLiteDBPathProvider sqLiteDbPathProvider,
            IGarbageDayRepository garbageDayRepository//,
            //MobileServiceClient client
        )
        {
            Debug.WriteLine("GarbageDayService() START");
            _client = MobileServiceClientFactory.create();
            _sqLiteDbPathProvider = sqLiteDbPathProvider;
            _garbageDayRepository = garbageDayRepository;
            Debug.WriteLine("GarbageDayService() END");
        }

        public async Task InitializeAsync()
        {
            var store = new MobileServiceSQLiteStore(_sqLiteDbPathProvider.GetPath());
            store.DefineTable<GarbageDay>();
            await _client.SyncContext.InitializeAsync(store);
            await _garbageDayRepository.SyncAsync();
            var garbageDays = await _garbageDayRepository.GetAllAsync();
            GarbageDays.Clear();
            foreach (var day in garbageDays)
            {
                GarbageDays.Add(day);
            }
        }
    }
}