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

            var rowDefinitions = new RowDefinition[rowNum];
            var rowCollections = new RowDefinitionCollection();
            for (var i = 0; i < rowNum; i++)
            {
                rowDefinitions[i] = new RowDefinition {Height = 40};
                rowCollections.Add(rowDefinitions[i]);
            }

            var columnDefinitions = new ColumnDefinition[7];
            var columnCollections = new ColumnDefinitionCollection();
            for (var i = 0; i < 7; i++)
            {
                columnDefinitions[i] = new ColumnDefinition {Width = 40};
                columnCollections.Add(columnDefinitions[i]);
            }

            calendarGrid.RowDefinitions = rowCollections;
            calendarGrid.ColumnDefinitions = columnCollections;

            var cells = new Cell[rowNum * 7];

            var prevMonthDay = CalendarUtils.CalcPrevMonthDays(year, month);

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
                    calendarGrid.Children.Add(cells[idx - 1], j - 1, i);
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

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine("OnNavigatingTo() called.{0}", parameters);

            var year = (int) parameters["year"];
            var month = (int) parameters["month"];

            UpdateView(year, month);
        }
    }
}