using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using garbage_calendar.Droid.Logic;
using garbage_calendar.Logic;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace garbage_calendar.Droid
{
	[Activity(Label = "garbage_calendar.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App(new AndroidInitializer()));
		}
	}

    public class AndroidInitializer : IPlatformInitializer
    {
        public  void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISQLiteDBPathProvider, SQLiteDBPathProvider>(
                new ContainerControlledLifetimeManager());
        }
    }
}
