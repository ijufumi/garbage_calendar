using Xamarin.Forms;

namespace garbage_calendar.Logic
{
    public class Cell : AbsoluteLayout
    {
        public static readonly BindableProperty YearProperty = BindableProperty.Create("Year", typeof (int), typeof (Xamarin.Forms.Cell), 2000, BindingMode.OneWay, null, OnYearValuePropertyChanged);
        public static readonly BindableProperty MonthProperty = BindableProperty.Create("Month", typeof (int), typeof (Xamarin.Forms.Cell), 1, BindingMode.OneWay, null, OnMonthValuePropertyChanged);
        public static readonly BindableProperty DayProperty = BindableProperty.Create("Day", typeof (int), typeof (Xamarin.Forms.Cell), 1, BindingMode.OneWay, null, OnDayValuePropertyChanged);
        public static readonly BindableProperty IndexProperty = BindableProperty.Create("Index", typeof (int), typeof (Xamarin.Forms.Cell), 0, BindingMode.OneWay, null, OnIndexValuePropertyChanged);

        public Cell(int year, int month, int day)
        {
            var label = new Label
            {
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };

            SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);
            SetLayoutBounds(label, new Rectangle(0, 0, 40, 40));

            Children.Add(label);

            UpdateDate(year, month, day);
        }

        public void UpdateDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            IsVisible = false;
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
        }

        private static void OnIndexValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
    }
}