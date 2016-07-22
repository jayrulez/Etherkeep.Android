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
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Etherkeep.Android.Services;

namespace Etherkeep.Android.Utilities
{
    public class ApiClient
    {
        const string BaseUrl = "http://server.etherkeep.com/api";
        protected AuthService AuthService;
        protected HttpHelper HttpHelper;

        public ApiClient(AuthService authService)
        {
            this.HttpHelper = new HttpHelper();
            this.AuthService = authService;
        }
        protected async Task<HttpResponseMessage> Get(string url, IDictionary<string, string> parameters = null)
        {
            var options = new HttpOptions();

            options.Method = HttpMethod.Get;
            options.Url = url;
            options.Params = parameters;

            return await this.Request(options);
        }
        protected async Task<HttpResponseMessage> Post(string url, IDictionary<string, string> data = null)
        {
            var options = new HttpOptions();

            options.Method = HttpMethod.Get;
            options.Url = url;
            options.Data = data;

            return await this.Request(options);
        }
        protected async Task<HttpResponseMessage> Request(HttpOptions options)
        {
            options.Url = GetAbsoluteUrl(options.Url);
            options.Headers = new Dictionary<string, string>() {
                {"Content-Type", "application/json"}
            };

            var accessToken = this.AuthService.GetAccessToken();

            if(accessToken != null)
            {
                options.Headers.Add("Authorization", "Bearer " + accessToken);
            }

            var response = await this.HttpHelper.RequestAsync(options);

            if(response.StatusCode == HttpStatusCode.Unauthorized && options.Headers.ContainsKey("Authorization"))
            {
                //Token may have expired
                //Refresh the token and retry the request
                this.AuthService.RefreshToken();

                accessToken = this.AuthService.GetAccessToken();

                options.Headers["Authorization"] = "Bearer " + accessToken;

                return await this.HttpHelper.RequestAsync(options);
            }

            return response;
        }

        private string GetAbsoluteUrl(string url)
        {
            var baseUrl = ApiClient.BaseUrl;

            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            return baseUrl + url;
        }
    }
}