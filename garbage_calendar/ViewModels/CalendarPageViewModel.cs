using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace garbage_calendar.ViewModels
{
    public class CalendarPageViewModel : BindableBase
    {
        public CalendarPageViewModel()
        {
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
        }

        public DelegateCommand<string> NextMonthClicked { get; }
        public DelegateCommand<string> PrevMonthClicked { get; }
        public DelegateCommand<int?> CellClicked { get; }

        async Task ShowNextMonthAsync(string month)
        {

        }
        async Task ShowPrevMonthAsync(string month)
        {

        }
        async Task CellClickAsync(int? day)
        {

        }

        private bool CanShowNext => true;
        private bool CanShowPrev => true;
        private bool CanCellClick => true;

    }

}