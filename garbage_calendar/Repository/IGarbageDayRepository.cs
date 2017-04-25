using System.Collections.Generic;
using System.Threading.Tasks;

namespace garbage_calendar.Repository
{
    public interface IGarbageDayRepository
    {
        Task<IEnumerable<GarbageDay>> GetAllAsync();
    }
}