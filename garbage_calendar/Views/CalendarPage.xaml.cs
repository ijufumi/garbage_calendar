using System;
using System.Diagnostics;
using garbage_calendar.Utils;
using garbage_calendar.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;
using Cell = garbage_calendar.Logic.Cell;

namespace garbage_calendar.Views
{
    public partial class CalendarPage : ContentPage, INavigatingAware
    {
        public CalendarPage()
        {
            InitializeComponent();

            Debug.WriteLine("Start CalendarPage()");
            //UpdateView(0, 0);
            Debug.WriteLine("End CalendarPage()");
        }

        private void UpdateView(int year, int month)
        {
            var viewModel = (CalendarPageViewModel) BindingContext;

            var rowNum = CalendarUtils.CalcRowSize(year, month);

            var rowCollections = new RowDefinitionCollection();
            rowCollections.Add(new RowDefinition {Height = 15});
            for (var i = 0; i < rowNum; i++)
            {
                rowCollections.Add(new RowDefinition {Height = 50});
            }

            var columnCollections = new ColumnDefinitionCollection();
            for (var i = 0; i < 7; i++)
            {
                columnCollections.Add(new ColumnDefinition {Width = 40});
            }

            calendarGrid.RowDefinitions = rowCollections;
            calendarGrid.ColumnDefinitions = columnCollections;

            var cells = new Cell[rowNum * 7];

            var prevMonthDay = CalendarUtils.CalcPrevMonthDays(year, month);

            Debug.WriteLine("曜日ラベル作成");
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Sunday), 0, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Monday), 1, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Tuesday), 2, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Wednesday), 3, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Thursday), 4, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Friday), 5, 0);
            calendarGrid.Children.Add(CreateHeaderLabel(DayOfWeek.Saturday), 6, 0);

            Debug.WriteLine("カレンダー作成");
            for (var i = 0; i < rowNum; i++)
            {
                for (var j = 1; j <= 7; j++)
                {
                    var idx = (i * 7) + j;
                    var dateTime = CalendarUtils.CalcDate(year, month, prevMonthDay, idx);
                    cells[idx - 1] = new Cell(dateTime.Year, dateTime.Month, dateTime.Day)
                    {
                        Index = idx - 1
                    };

                    if (dateTime.Year == year && dateTime.Month == month)
                    {
                        cells[idx - 1].BackgroundColor = Color.White;
                    }
                    else
                    {
                        cells[idx - 1].BackgroundColor = Color.Gray;
                    }
                    Debug.WriteLine("{0}-{1}-{2}", dateTime.Year, dateTime.Month, dateTime.Day);

                    cells[idx - 1].GestureRecognizers.Add(
                        new TapGestureRecognizer
                        {
                            Command = viewModel.CellClicked,
                            CommandParameter = idx - 1
                        }
                    );
                    calendarGrid.Children.Add(cells[idx - 1], j - 1, i + 1);
                }
            }

            var pickerDateTime = new DateTime(year, month, 1);
            thisMonth.Text = string.Format("{0}年{1}月", pickerDateTime.Year, pickerDateTime.Month);

            pickerDateTime = pickerDateTime.AddMonths(-1);
            toPrevMonth.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = viewModel.PrevMonthClicked,
                    CommandParameter = string.Format("{0}{1}", pickerDateTime.Year, pickerDateTime.Month)
                }
            );
            pickerDateTime = pickerDateTime.AddMonths(2);
            toNextMonth.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = viewModel.NextMonthClicked,
                    CommandParameter = string.Format("{0}{1}", pickerDateTime.Year, pickerDateTime.Month)
                }
            );
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

            Debug.WriteLine("CreateHeaderLabel()");
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

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine("OnNavigatingTo() called.{0}", parameters);

            var year = (int) parameters["year"];
            var month = (int) parameters["month"];

            UpdateView(year, month);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}