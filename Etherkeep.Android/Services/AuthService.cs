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
using Android.Util;
using System.Threading.Tasks;
using Etherkeep.Android.Utilities;
using Newtonsoft.Json;
using Etherkeep.Android.Models;

namespace Etherkeep.Android.Services
{
    public class AuthService
    {
        const string LOG_TAG = "AuthService";
        const string AUTH_PREFERENCES = "Auth";

        const string BaseUrl = "http://server.etherkeep.com";

        private Context Context;
        private HttpHelper HttpHelper;


        public bool IsSignedIn
        {
            get
            {
                return this.GetAccessToken() != null;
            }
        }

        public AuthService(Context context)
        {
            Log.Debug(LOG_TAG, "Initializing AuthService.");
            this.Context = context;
            this.HttpHelper = new HttpHelper();
        }

        private string GetAbsoluteUrl(string url)
        {
            var baseUrl = AuthService.BaseUrl;

            if(!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            return baseUrl + url;
        }
        public async Task SigninAsync(string username, string password)
        {
            var url = this.GetAbsoluteUrl("connect/token");

            var data = new Dictionary<string, string>() {
                {"grant_type", "password"},
                //{"client_id", "" },
                //{"client_secret", "" },
                {"username", username },
                {"password", password },
                {"scope", "openid offline_access profile email"}
            };

            var headers = new Dictionary<string, string>() {
               { "Content-Type", "application/x-www-form-url-urlencoded" }
            };

            try
            {
                var response = await HttpHelper.PostAsync(url, data, headers);
                var responseContent = await response.Content.ReadAsStringAsync();
                Log.Debug(LOG_TAG, responseContent);

                if (response.IsSuccessStatusCode)
                {
                    var token = JsonConvert.DeserializeObject<TokenModel>(responseContent);

                    Log.Debug(LOG_TAG, "access_token: " + token.AccessToken);

                    var editor = this.GetAuthPreferences().Edit();

                    editor.PutString("access_token", token.AccessToken);

                    if(!string.IsNullOrEmpty(token.RefreshToken))
                    {
                        editor.PutString("refresh_token", token.RefreshToken);
                    }

                    if (!string.IsNullOrEmpty(token.IdToken))
                    {
                        editor.PutString("id_token", token.IdToken);
                    }

                    if(!editor.Commit())
                    {
                        throw new AuthenticationException("Unable to save authentication information.");
                    }
                }
                else
                {
                    throw new AuthenticationException("Invalid grant");
                }
            }catch(System.Exception ex)
            {
                Log.Error(LOG_TAG, ex.Message);

                throw new AuthenticationException("Unexpected error");
            }
        }

        public async void RefreshTokenAsync()
        {
            var url = this.GetAbsoluteUrl("token");

            var data = new Dictionary<string, string>() {
                {"grant_type", "refresh_token"},
                {"refresh_token", "" }
            };

            var headers = new Dictionary<string, string>() {
               { "Content-Type", "application/x-www-form-url-urlencoded" }
            };

            try
            {
                var response = await HttpHelper.PostAsync(url, data, headers);
                var responseContent = await response.Content.ReadAsStringAsync();
                Log.Debug(LOG_TAG, responseContent);

                if (response.IsSuccessStatusCode)
                {
                    var token = JsonConvert.DeserializeObject<TokenModel>(responseContent);

                    Log.Debug(LOG_TAG, "access_token: " + token.AccessToken);

                    var editor = this.GetAuthPreferences().Edit();

                    editor.PutString("access_token", token.AccessToken);

                    if (!string.IsNullOrEmpty(token.RefreshToken))
                    {
                        editor.PutString("refresh_token", token.RefreshToken);
                    }

                    if (!string.IsNullOrEmpty(token.IdToken))
                    {
                        editor.PutString("id_token", token.IdToken);
                    }

                    if (!editor.Commit())
                    {
                        throw new AuthenticationException("Unable to save authentication information.");
                    }
                }
                else
                {
                    throw new AuthenticationException("Invalid grant");
                }
            }
            catch (System.Exception ex)
            {
                Log.Debug(LOG_TAG, ex.Message);

                throw new AuthenticationException("Unexpected error");
            }
        }

        public string GetAccessToken()
        {
            var preferences = this.GetAuthPreferences();

            if(preferences == null)
            {
                return null;
            }

            var accessToken = preferences.GetString("access_token", null);

            return accessToken;
        }

        public string GetRefreshToken()
        {
            var preferences = this.GetAuthPreferences();

            if (preferences == null)
            {
                return null;
            }

            var accessToken = preferences.GetString("refresh_token", null);

            return accessToken;
        }

        protected ISharedPreferences GetAuthPreferences()
        {
            var authPreferences = this.Context.ApplicationContext.GetSharedPreferences(AUTH_PREFERENCES,FileCreationMode.Private);

            return authPreferences;
        }
    }
}