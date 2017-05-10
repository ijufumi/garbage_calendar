using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using garbage_calendar.Droid.Logic;
using garbage_calendar.Logic;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace garbage_calendar.Droid
{
	[Activity(Label = "garbage_calendar.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			System.Diagnostics.Debug.WriteLine("MainActivity.OnCreate START");
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			LoadApplication(new App(new AndroidInitializer()));
			System.Diagnostics.Debug.WriteLine("MainActivity.OnCreate END");
		}
	}

    public class AndroidInitializer : IPlatformInitializer
    {
        public  void RegisterTypes(IUnityContainer container)
        {
	        System.Diagnostics.Debug.WriteLine("MainActivity.RegisterTypes START");
            container.RegisterType<ISQLiteDBPathProvider, SQLiteDBPathProvider>(
                new ContainerControlledLifetimeManager());
	        System.Diagnostics.Debug.WriteLine("MainActivity.RegisterTypes END");
        }
    }
}
