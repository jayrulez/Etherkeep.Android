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
using Etherkeep.Android.Models.Enums;

namespace Etherkeep.Android.Models
{
    public class SigninModel
    {
        public IdentityType IdentityType { get; set; }
        public string CountryCallingCode { get; set; }
        public string AreaCode { get; set; }
        public string SubscriberNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}