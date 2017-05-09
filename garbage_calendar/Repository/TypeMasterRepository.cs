using System.Collections.Generic;
using System.Threading.Tasks;

namespace garbage_calendar.Repository
{
    public class TypeMasterRepository : ITypeMasterRepository
    {
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