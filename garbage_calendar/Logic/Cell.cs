using Xamarin.Forms;

namespace garbage_calendar.Logic
{
    public class Cell : AbsoluteLayout
    {
        public static readonly BindableProperty YearProperty = BindableProperty.Create("Year", typeof (int), typeof (Xamarin.Forms.Cell), 2000, BindingMode.TwoWay, null, OnDateValuePropertyChanged);
        public static readonly BindableProperty MonthProperty = BindableProperty.Create("Month", typeof (int), typeof (Xamarin.Forms.Cell), 1, BindingMode.TwoWay, null, OnDateValuePropertyChanged);
        public static readonly BindableProperty DayProperty = BindableProperty.Create("Day", typeof (int), typeof (Xamarin.Forms.Cell), 1, BindingMode.TwoWay, null, OnDateValuePropertyChanged);

        public Cell(int year, int month, int day)
        {
            UpdateDate(year, month, day);
        }

        public void UpdateDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
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
        private static void OnDateValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
    }
}