using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace garbage_calendar.ViewModels
{
    public class CalendarPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        public CalendarPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Debug.WriteLine("Start CalendarPageViewModel()");
            NextMonthClicked = new DelegateCommand<string>(
                async (T) => await ShowNextMonthAsync(T),
                T => CanShowNext
            ).ObservesProperty(() => CanShowNext);

            PrevMonthClicked = new DelegateCommand<string>(
                async (T) => await ShowPrevMonthAsync(T),
                T => CanShowPrev
            ).ObservesProperty(() => CanShowPrev);

            CellClicked = new DelegateCommand<int?>(
                async (T) => await CellClickAsync(T),
                T => CanCellClick
            ).ObservesProperty(() => CanCellClick);


            Debug.WriteLine("End CalendarPageViewModel()");
        }

        public DelegateCommand<string> NextMonthClicked { get; }
        public DelegateCommand<string> PrevMonthClicked { get; }
        public DelegateCommand<int?> CellClicked { get; }

        async Task ShowNextMonthAsync(string month)
        {
            _navigationService.NavigateAsync("CalendarPage");
        }
        async Task ShowPrevMonthAsync(string month)
        {
            _navigationService.NavigateAsync("CalendarPage");
        }
        async Task CellClickAsync(int? day)
        {
            Debug.WriteLine("Cell clicked.{0}", day);
        }

        private bool CanShowNext => true;
        private bool CanShowPrev => true;
        private bool CanCellClick => true;

    }

}