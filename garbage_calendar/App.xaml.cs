using System;
using System.Diagnostics;
using System.Net.Http;
using garbage_calendar.Logic;
using garbage_calendar.Repository;
using garbage_calendar.Views;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.MobileServices;
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
	        Debug.WriteLine("OnIntialized() START.");
	        InitializeComponent();
	        NavigationService.NavigateAsync("/RootPage/NavigationPage/CalendarPage");
	        Debug.WriteLine("OnIntialized() END.");
	    }

	    protected override void RegisterTypes()
	    {
	        Debug.WriteLine("App.RegisterTypes() START.");
		    Container.RegisterTypeForNavigation<RootPage>();
	        Container.RegisterTypeForNavigation<NavigationPage>();
	        Container.RegisterTypeForNavigation<CalendarPage>();
            Container.RegisterTypeForNavigation<EditCalendarDataPage>();
            Container.RegisterTypeForNavigation<EditMasterDataPage>();
	        Container.RegisterType<MobileServiceClient>(
	            new ContainerControlledLifetimeManager(),
	            new InjectionConstructor(
	                new Uri("https://garbage-calendar.azurewebsites.net"),
	                new HttpMessageHandler[] { }));
	        Container.RegisterType<GarbageDayService>(new ContainerControlledLifetimeManager());
	        Container.RegisterType<IGarbageDayRepository, GarbageDayRepository>(new ContainerControlledLifetimeManager());
	        Debug.WriteLine("App.RegisterTypes() END.");
	    }
	}
}
