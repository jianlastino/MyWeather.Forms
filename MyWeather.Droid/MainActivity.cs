
using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.Permissions;
using Android.Content.PM;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;

namespace MyWeather.Droid
{
    [Activity(Label = "@string/app_name",
    Icon = "@mipmap/ic_launcher",
    LaunchMode = LaunchMode.SingleTask,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {

		protected override void OnCreate (Bundle bundle)
		{
			
		    ToolbarResource = Resource.Layout.Toolbar;
		    TabLayoutResource = Resource.Layout.Tabbar;
            Microsoft.AppCenter.AppCenter.Start("477babc0-a62f-440c-892f-5c24cf7dcd58", typeof(Analytics), typeof(Crashes),typeof(Push));
            Push.SetSenderId("998482667532");


            var a = Push.IsEnabledAsync();
            base.OnCreate (bundle);

		    Forms.Init(this, bundle);
		
		    LoadApplication(new App());
            //Crashes.GenerateTestCrash();
            
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}


