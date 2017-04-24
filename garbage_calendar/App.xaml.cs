using System;
using garbage_calendar.Views;
using Prism.Navigation;
using Prism.Unity;
using Xamarin.Forms;

namespace garbage_calendar
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer)
		{
		}

	    protected override void OnInitialized()
	    {
	        InitializeComponent();
	        var dateTime = DateTime.Now;
	        var parameters = new NavigationParameters {{"year", dateTime.Year}, {"month", dateTime.Month}};

	        NavigationService.NavigateAsync("NavigationPage/CalendarPage", parameters);
	    }

	    protected override void RegisterTypes()
	    {
	        Container.RegisterTypeForNavigation<NavigationPage>();
	        Container.RegisterTypeForNavigation<CalendarPage>();
	    }
	}
}
