using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using garbage_calendar.Logic;
using garbage_calendar.Repository;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace garbage_calendar.ViewModels
{
    public class CalendarPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly GarbageDayService _garbageDayService;

        public CalendarPageViewModel(INavigationService navigationService,
            GarbageDayService garbageDayService
        )
        {
            _navigationService = navigationService;
            _garbageDayService = garbageDayService;

            Debug.WriteLine("Start CalendarPageViewModel()");

            NextMonthClicked = new DelegateCommand<string>(
                async (T) => await ShowNextMonthAsync(T),
                (T) => CanShowNext
            ).ObservesProperty(() => CanShowNext);

            PrevMonthClicked = new DelegateCommand<string>(
                async (T) => await ShowPrevMonthAsync(T),
                (T) => CanShowPrev
            ).ObservesProperty(() => CanShowPrev);

            CellClicked = new DelegateCommand<int?>(
                async (T) => await CellClickAsync(T),
                T => CanCellClick
            ).ObservesProperty(() => CanCellClick);

            Debug.WriteLine("End CalendarPageViewModel()");

            // _garbageDayService.InitializeAsync();
        }

        public DelegateCommand<string> NextMonthClicked { get; }
        public DelegateCommand<string> PrevMonthClicked { get; }
        public DelegateCommand<int?> CellClicked { get; }

        async Task ShowNextMonthAsync(string yyyyMM)
        {
            var year = yyyyMM.Substring(0, 4);
            var month = yyyyMM.Substring(4);

            Debug.WriteLine("[Next] {0}/{1}", year, month);

            var dateTime = new DateTime(Int32.Parse(year), Int32.Parse(month), 1);
            var parameters = new NavigationParameters();

            parameters.Add("year", dateTime.Year);
            parameters.Add("month", dateTime.Month);

            _navigationService.NavigateAsync("/RootPage/NavigationPage/CalendarPage", parameters, animated: false);
        }
        
        async Task ShowPrevMonthAsync(string yyyyMM)
        {
            var year = yyyyMM.Substring(0, 4);
            var month = yyyyMM.Substring(4);

            Debug.WriteLine("[Prev] {0}/{1}", year, month);

            var dateTime = new DateTime(Int32.Parse(year), Int32.Parse(month), 1);
            var parameters = new NavigationParameters();

            
            parameters.Add("year", dateTime.Year);
            parameters.Add("month", dateTime.Month);

            _navigationService.NavigateAsync("/RootPage/NavigationPage/CalendarPage", parameters, animated: false);
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