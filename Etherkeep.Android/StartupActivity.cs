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

namespace Etherkeep.Android
{
    [Activity(Label = "StartupActivity")]
    public class StartupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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