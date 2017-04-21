using System;
using Xamarin.Forms;

namespace garbage_calendar.Logic
{
    public class Cell : StackLayout
    {
        public static readonly BindableProperty YearProperty = BindableProperty.Create("Year", typeof (int), typeof (Xamarin.Forms.Cell), 1900, BindingMode.OneWay, null, OnYearValuePropertyChanged);
        public static readonly BindableProperty MonthProperty = BindableProperty.Create("Month", typeof (int), typeof (Xamarin.Forms.Cell), 0, BindingMode.OneWay, null, OnMonthValuePropertyChanged);
        public static readonly BindableProperty DayProperty = BindableProperty.Create("Day", typeof (int), typeof (Xamarin.Forms.Cell), 0, BindingMode.OneWay, null, OnDayValuePropertyChanged);
        public static readonly BindableProperty IndexProperty = BindableProperty.Create("Index", typeof (int), typeof (Xamarin.Forms.Cell), 0, BindingMode.OneWay, null, OnIndexValuePropertyChanged);

        public Cell(int year, int month, int day)
        {
            Spacing = 0;
            VerticalOptions = LayoutOptions.FillAndExpand;

            var label = new Label
            {
                FontSize = 12,
                HorizontalOptions = LayoutOptions.End
            };

            // TODO 画像を透過にする
            var image = new Image
            {
                Source = "default_image.png",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Children.Add(label);
            Children.Add(image);

            UpdateDate(year, month, day);
        }

        public void UpdateDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            IsVisible = true;
        }

        public int Year
        {
            get { return (int) GetValue(YearProperty); }
            set
            {
                SetValue(YearProperty, value);
            }
        }
        public int Month
        {
            get { return (int) GetValue(MonthProperty); }
            set
            {
                SetValue(MonthProperty, value);
            }
        }
        public int Day
        {
            get { return (int) GetValue(DayProperty); }
            set
            {
                SetValue(DayProperty, value);
            }
        }

        public int Index
        {
            get { return (int) GetValue(IndexProperty); }
            set
            {
                SetValue(IndexProperty, value);
            }
        }

        private static void OnYearValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
        private static void OnMonthValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
        private static void OnDayValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var cell = (Cell) bindable;
            (cell.Children[0] as Label).Text = ((int) newvalue).ToString();

            UpdateDayColor(cell);
        }

        private static void UpdateDayColor(Cell cell)
        {
            var dateTime = new DateTime(cell.Year, cell.Month, cell.Day);
            var dayOfWeek = dateTime.DayOfWeek;
            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday:
                    (cell.Children[0] as Label).TextColor = Color.Blue;
                    break;
                case DayOfWeek.Sunday:
                    (cell.Children[0] as Label).TextColor = Color.Red;
                    break;
            }
        }
        private static void OnIndexValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
    }
}