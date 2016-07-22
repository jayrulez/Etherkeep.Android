using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Etherkeep.Android
{
    [Activity(Label = "Etherkeep", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashActivity : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Splash);

            if(this.AppContext.GetAuthService().IsSignedIn)
            {
                StartActivity(typeof(MainActivity));
            }else
            {
                StartActivity(typeof(StartupActivity));
            }

            Finish();
        }
    }
}

