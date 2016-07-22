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

namespace Etherkeep.Android.Services
{
    abstract public class BaseApiService
    {
        protected ApiClient ApiClient;

        public BaseApiService(AuthService authService)
        {
            this.ApiClient = new ApiClient(authService);
        }
    }
}