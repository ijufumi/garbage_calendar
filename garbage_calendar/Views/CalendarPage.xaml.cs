using System;
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

            var viewModel = (CalendarPageViewModel) BindingContext;
        }
    }
}