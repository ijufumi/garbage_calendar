using System.Collections.Generic;
using System.Threading.Tasks;

namespace garbage_calendar.Repository
{
    public interface ITypeMasterRepository
    {
        Task<IEnumerable<TypeMaster>> GetAllAsync();

        Task SyncAsync();
    }
}