using garbage_calendar.Repository;
using Prism.Mvvm;

namespace garbage_calendar.ViewModels
{
    public class EditDataPageViewModel : BindableBase
    {
        private IGarbageDayRepository _garbageDayRepository;

        public EditDataPageViewModel(IGarbageDayRepository garbageDayRepository)
        {
            _garbageDayRepository = garbageDayRepository;
        }
    }
}