using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace garbage_calendar.ViewModels
{
    public class RootPageViewModel : BindableBase
    {
        public ObservableCollection<MenuItem> Menus { get; } = new ObservableCollection<MenuItem>
        {
            new MenuItem
            {
                Title = "Main",
                PageName = "CalendarPage"
            },
            new MenuItem
            {
                Title = "EditCalendar",
                PageName = "EditCalendarDataPage"
            },
            new MenuItem
            {
                Title = "EditMaster",
                PageName = "EditMasterDataPage"
            }
        };

        private INavigationService NavigationService { get; }

        private bool isPresented;

        public bool IsPresented
        {
            get => isPresented;
            set => SetProperty(ref isPresented, value);
        }

        public RootPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public async Task PageChangeAsync(MenuItem menuItem)
        {
            await NavigationService.NavigateAsync($"NavigationPage/{menuItem.PageName}");
            IsPresented = false;
        }
    }
}