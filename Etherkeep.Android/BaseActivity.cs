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
using Etherkeep.Android.Services;
using Etherkeep.Android.Utilities;

namespace Etherkeep.Android
{
    abstract public class BaseActivity : Activity
    {
        protected HttpHelper HttpHelper;
        protected AuthService AuthService;
        protected ApiClient ApiClient;

        public BaseActivity()
        {
            this.AuthService = new AuthService(this);
            this.ApiClient = new ApiClient(this.AuthService);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}