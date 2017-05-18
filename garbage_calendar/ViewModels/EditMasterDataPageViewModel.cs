using System;
using System.Threading.Tasks;
using garbage_calendar.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace garbage_calendar.ViewModels
{
    public class EditMasterDataPageViewModel : BindableBase
    {
        private ITypeMasterRepository _typeMasterRepository;
        private readonly INavigationService _navigationService;

        public EditMasterDataPageViewModel(
            INavigationService navigationService,
            ITypeMasterRepository typeMasterRepository
        )
        {
            _navigationService = navigationService;
            _typeMasterRepository = typeMasterRepository;
        }
    }
}