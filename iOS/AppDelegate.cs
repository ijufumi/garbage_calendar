using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using garbage_calendar.iOS.Logic;
using garbage_calendar.Logic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using UIKit;

namespace garbage_calendar.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
		    Debug.WriteLine("AppDelegate.FinishedLaunching START.");
			global::Xamarin.Forms.Forms.Init();
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
		    Debug.WriteLine("AppDelegate.FinishedLaunching Forms.Init().");

			LoadApplication(new App(new iOSInitializer()));

		    Debug.WriteLine("AppDelegate.LoadApplication().");

			return base.FinishedLaunching(app, options);
		}

		[Export("application:supportedInterfaceOrientationsForWindow:")]
		public UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, IntPtr forWindow)
		{
			return UIInterfaceOrientationMask.Portrait;
		}

	}

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISQLiteDBPathProvider, SQLiteDBPathProvider>(
                new ContainerControlledLifetimeManager());
            Debug.WriteLine("AppDelegate.RegisterTypes called.");
        }
    }
}
