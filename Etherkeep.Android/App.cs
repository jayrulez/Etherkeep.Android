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
using Android.Util;

namespace Etherkeep.Android
{
    [Application]
    public class App: Application
    {
        const string LOG_TAG = "App";
        
        private AuthService _authService;
        private ApiClient _apiClient;
        private AccountService _accountService;

        public App(IntPtr handle, JniHandleOwnership transfer)
            : base(handle,transfer)
        {
            Log.Debug(LOG_TAG, "Initializing application.");

            this._authService = new AuthService(this);
            this._apiClient = new ApiClient(this._authService);
            this._accountService = new AccountService(this._apiClient);
        }

        public AuthService GetAuthService()
        {
            return this._authService;
        }

        public ApiClient GetApiCLient()
        {
            return this._apiClient;
        }
    }
}