using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace garbage_calendar.ViewModels
{
    public class CalendarPageViewModel : BindableBase, INavigatingAware
    {
        private INavigationService _navigationService;

        private int _year;
        private int _month;

        public CalendarPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Debug.WriteLine("Start CalendarPageViewModel()");
            NextMonthClicked = new DelegateCommand(
                async () => await ShowNextMonthAsync(),
                () => CanShowNext
            ).ObservesProperty(() => CanShowNext);

            PrevMonthClicked = new DelegateCommand(
                async () => await ShowPrevMonthAsync(),
                () => CanShowPrev
            ).ObservesProperty(() => CanShowPrev);

            CellClicked = new DelegateCommand<int?>(
                async (T) => await CellClickAsync(T),
                T => CanCellClick
            ).ObservesProperty(() => CanCellClick);


            Debug.WriteLine("End CalendarPageViewModel()");
        }

        public DelegateCommand NextMonthClicked { get; }
        public DelegateCommand PrevMonthClicked { get; }
        public DelegateCommand<int?> CellClicked { get; }

        async Task ShowNextMonthAsync()
        {
            var dateTime = new DateTime(_year, _month, 1);
            dateTime = dateTime.AddMonths(1);
            var parameters = new NavigationParameters();

            parameters.Add("year", dateTime.Year);
            parameters.Add("month", dateTime.Month);

            _navigationService.NavigateAsync("CalendarPage", parameters);
        }
        async Task ShowPrevMonthAsync()
        {
            var dateTime = new DateTime(_year, _month, 1);
            dateTime = dateTime.AddMonths(-1);
            var parameters = new NavigationParameters();

            parameters.Add("year", dateTime.Year);
            parameters.Add("month", dateTime.Month);

            _navigationService.NavigateAsync("CalendarPage");
        }
        async Task CellClickAsync(int? day)
        {
            Debug.WriteLine("Cell clicked.{0}", day);
        }

        private bool CanShowNext => true;
        private bool CanShowPrev => true;
        private bool CanCellClick => true;

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("year"))
            {
                _year = (int) parameters["year"];
            }
            if (parameters.ContainsKey("month"))
            {
                _month = (int) parameters["month"];
            }
        }
    }

}