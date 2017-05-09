using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace garbage_calendar.Repository
{
    public class TypeMasterRepository : ITypeMasterRepository
    {
        private MobileServiceClient _client;

        public TypeMasterRepository(
            MobileServiceClient client
        )
        {
            _client = client;
        }

        public Task<IEnumerable<TypeMaster>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task SyncAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}