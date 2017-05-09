using garbage_calendar.Repository;
using Prism.Mvvm;

namespace garbage_calendar.ViewModels
{
    public class EditMasterDataPageViewModel : BindableBase
    {
        private ITypeMasterRepository _typeMasterRepository;

        public EditMasterDataPageViewModel(ITypeMasterRepository typeMasterRepository)
        {
            _typeMasterRepository = typeMasterRepository;
        }
    }
}