using System;
using garbage_calendar.Views;
using Prism.Unity;
using Xamarin.Forms;

namespace garbage_calendar
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer) : base(initializer)
		{
		}

	    protected override void OnInitialized()
	    {
	        InitializeComponent();
	        NavigationService.NavigateAsync("NavigationPage/CalendarPage");
	    }

	    protected override void RegisterTypes()
	    {
	        Container.RegisterTypeForNavigation<NavigationPage>();
	        Container.RegisterTypeForNavigation<CalendarPage>();
	    }
	}
}
