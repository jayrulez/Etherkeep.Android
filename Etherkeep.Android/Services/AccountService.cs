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

namespace Etherkeep.Android.Services
{
    class AccountService : BaseApiService
    {
        const string LOG_TAG = "AccountService";
        public AccountService(ApiClient apiClient) : base(apiClient)
        {
            Log.Debug(LOG_TAG, "Initializing AccountService.");
        }
        public void Signup()
        {

        }
    }
}