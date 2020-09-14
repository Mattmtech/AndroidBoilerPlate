using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TheAndroidPoc.TheView
{
    [Activity(Theme = "@style/SplashPage", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle bundle)
        {
            base.OnCreate(savedInstanceState, bundle);
            Thread.Sleep(2000);//TODO REMOVE THIS UNNECESSARY
            // DO any necessary checking if user is already logged in /  loading / establishing connections below here. 
        }

        public override void OnBackPressed()
        {
            
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(OnboardingActivity));
        }

    }
}