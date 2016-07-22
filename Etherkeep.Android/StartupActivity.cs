using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Etherkeep.Android.Utilities;
using Android.Util;

namespace Etherkeep.Android
{
    [Activity(Label = "StartupActivity")]
    public class StartupActivity : BaseActivity
    {
        const string LOG_TAG = "StartupActivity";
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Startup);
            
            try
            {
                var response = await this.HttpHelper.GetAsync("http://api.dev.caricoin.com/v1/public/exchange_rates");

                Log.Debug(LOG_TAG, await response.Content.ReadAsStringAsync());
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch(Exception ex)
            {
                Log.Debug(LOG_TAG, ex.Message);
                Console.WriteLine(ex.Message);
            }

            var signupButton = FindViewById<Button>(Resource.Id.buttonSignup);

            signupButton.Click += (sender, args) => {
                StartActivity(typeof(SignupActivity));
            };

            var signinButton = FindViewById<Button>(Resource.Id.buttonSignin);

            signinButton.Click += (sender, args) => {
                StartActivity(typeof(SigninActivity));
            };
        }
    }
}