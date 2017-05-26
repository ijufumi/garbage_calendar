using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using garbage_calendar.Utils;
using garbage_calendar.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using Cell = garbage_calendar.Logic.Cell;

namespace garbage_calendar.Views
{
    public partial class CalendarPage : ContentPage
    {
        public static int CalendarGridHeight { get; private set; }

        private int _year;
        private int _month;
        
        public CalendarPage()
        {
            Debug.WriteLine("Start CalendarPage()");

            InitializeComponent();

            NextMonthClicked = new DelegateCommand<int?>(
                async (T) => await MoveMonthAsync(T)
            );

            PrevMonthClicked = new DelegateCommand<int?>(
                async (T) => await MoveMonthAsync(T)
            );

            var dateTime = DateTime.Now;
            _year = dateTime.Year;
            _month = dateTime.Month;
            
            SizeChanged += (s, a) =>
            {
                InitView();
                UpdateCalendar();
            };

            //UpdateView(0, 0);
            Debug.WriteLine("End CalendarPage()");
        }

        private void InitView()
        {
            Debug.WriteLine("Start InitView() Height:{0} Width:{1}", Height, Width);

            var headerRowHeight = (int) (Height / 10);
            var headerColumnWidth = (int) Width / 9;

            header.RowDefinitions[0].Height = headerRowHeight;
            header.ColumnDefinitions[0].Width = headerColumnWidth;
            header.ColumnDefinitions[2].Width = headerColumnWidth;

            toPrevMonth.HeightRequest = headerRowHeight;
            toNextMonth.HeightRequest = headerRowHeight;

            thisMonth.FontSize = 30 * (headerRowHeight / 30);
            
            toPrevMonth.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = PrevMonthClicked,
                    CommandParameter = -1
                }
            );
            toNextMonth.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = NextMonthClicked,
                    CommandParameter = 1
                }
            );
            
            var calendarColumnWidth = (int) (Width * 0.9) / 7;
            var columnCollections = new ColumnDefinitionCollection();
            for (var i = 0; i < 7; i++)
            {
                columnCollections.Add(new ColumnDefinition {Width = calendarColumnWidth});
            }
            calendarGrid.ColumnDefinitions = columnCollections;

            InitCalendarHeader();            
            Debug.WriteLine("End InitView()");
        }

        private void InitCalendarHeader()
        {
            Debug.WriteLine("Start InitCalendarHeader()");
            var calendarHeaderRowHeight = (int) (Height * 0.05);
            calendarGrid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition{Height = calendarHeaderRowHeight}
            };
            
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Sunday), 0, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Monday), 1, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Tuesday), 2, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Wednesday), 3, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Thursday), 4, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Friday), 5, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Saturday), 6, 0);
   
            Debug.WriteLine("End InitCalendarHeader()");
        }
        
        private void UpdateCalendar()
        {
            Debug.WriteLine("Start UpdateCalendar()");
            
            var rowNum = CalendarUtils.CalcRowSize(_year, _month);

            var calendarDateRowHeight = (Height * 0.8) / rowNum;
            var rowCollections = new RowDefinitionCollection();
            rowCollections.Add(calendarGrid.RowDefinitions[0]);
            for (var i = 0; i < rowNum; i++)
            {
                rowCollections.Add(new RowDefinition {Height = calendarDateRowHeight});
            }

            calendarGrid.RowDefinitions = rowCollections;

            var prevMonthDay = CalendarUtils.CalcPrevMonthDays(_year, _month);

            Debug.WriteLine("既存のカレンダー削除");
            calendarGrid.Children.Clear();

            Debug.WriteLine("カレンダー作成");
            InitCalendarHeader();
            for (var i = 0; i < rowNum; i++)
            {
                for (var j = 1; j <= 7; j++)
                {
                    var idx = (i * 7) + j;
                    var dateTime = CalendarUtils.CalcDate(_year, _month, prevMonthDay, idx);
                    var cell = new Cell(dateTime.Year, dateTime.Month, dateTime.Day)
                    {
                        Index = idx - 1
                    };

                    if (dateTime.Year == _year && dateTime.Month == _month)
                    {
                        cell.BackgroundColor = Color.White;
                    }
                    else
                    {
                        cell.BackgroundColor = Color.Gray;
                    }
                    Debug.WriteLine("{0}-{1}-{2}", dateTime.Year, dateTime.Month, dateTime.Day);
                    calendarGrid.Children.Add(cell, j - 1, i + 1);
                }
            }

            var pickerDateTime = new DateTime(_year, _month, 1);
            thisMonth.Text = $"{pickerDateTime.Year}年{pickerDateTime.Month}月";
            
            Debug.WriteLine("End UpdateCalendar()");
        }
        
        private Label CreateHeaderLabel(DayOfWeek week)
        {
            var labelColor = Color.Black;
            switch (week)
            {
                case DayOfWeek.Sunday:
                    labelColor = Color.Red;
                    break;
                case DayOfWeek.Saturday:
                    labelColor = Color.Blue;
                    break;
            }

            return new Label
            {
                TextColor = labelColor,
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.White,
                Text = week.ToString().Substring(0, 3)
            };
        }

        public DelegateCommand<int?> NextMonthClicked { get; }
        public DelegateCommand<int?> PrevMonthClicked { get; }
        
        async Task MoveMonthAsync(int? value)
        {
            var dateTime = new DateTime(_year, _month, 1);
            dateTime = dateTime.AddMonths(value ?? 0);
            _year = dateTime.Year;
            _month = dateTime.Month;

            Debug.WriteLine("[MoveTo] {0}/{1}", _year, _month);

            UpdateCalendar();
        }
        
        async Task ShowNextMonthAsync()
        {
            var dateTime = new DateTime(_year, _month, 1);
            dateTime = dateTime.AddMonths(1);
            _year = dateTime.Year;
            _month = dateTime.Month;

            Debug.WriteLine("[Next] {0}/{1}", _year, _month);

            UpdateCalendar();
        }
        
        async Task ShowPrevMonthAsync()
        {
            var dateTime = new DateTime(_year, _month, 1);
            dateTime = dateTime.AddMonths(-1);
            _year = dateTime.Year;
            _month = dateTime.Month;

            Debug.WriteLine("[Next] {0}/{1}", _year, _month);

            UpdateCalendar();
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}