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
        protected App AppContext
        {
            get
            {
                return (App)this.ApplicationContext;
            }
        }

        public BaseActivity()
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}