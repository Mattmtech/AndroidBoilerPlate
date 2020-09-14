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

namespace TheAndroidPoc.TheView
{
    public class User
    {
        private string user { get; set; }
        private string pass { get; set; }

        public User(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
        }


    }
}