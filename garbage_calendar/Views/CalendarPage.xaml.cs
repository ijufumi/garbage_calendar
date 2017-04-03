using System;
using System.Diagnostics;
using garbage_calendar.Utils;
using Xamarin.Forms;
using garbage_calendar.ViewModels;

namespace garbage_calendar.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();

            Debug.WriteLine("Start CalendarPage()");

            var rowNum = CalendarUtils.CalcRowSize(2017, 3);

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

            var cells = new Logic.Cell[rowNum * 7];

            var prevMonthDay = CalendarUtils.CalcPrevMonthDays(2017, 3);

            var viewModel = (CalendarPageViewModel) BindingContext;

            for (var i = 0; i < rowNum; i++)
            {
                for (var j = 1; j <= 7; j++)
                {
                    var idx = (i * 7) + j;
                    var dateTime = CalendarUtils.CalcDate(2017, 3, prevMonthDay, idx);
                    cells[idx - 1] = new Logic.Cell(dateTime.Year, dateTime.Month, dateTime.Day);

                    if (dateTime.Year == 2017 && dateTime.Month == 3)
                    {
                        cells[idx - 1].BackgroundColor = Color.White;
                    }
                    else
                    {
                        cells[idx - 1].BackgroundColor = Color.Gray;
                    }
                    Debug.WriteLine("{0}-{1}-{2}", dateTime.Year, dateTime.Month, dateTime.Day);
                    calendarGrid.Children.Add(cells[idx - 1], j - 1, i);
                }
            }

            Debug.WriteLine("End CalendarPage()");
        }
    }
}