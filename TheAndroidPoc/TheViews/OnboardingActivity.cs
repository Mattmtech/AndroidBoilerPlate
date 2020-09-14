using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace TheAndroidPoc.TheView
{
    [Activity(Theme = "@style/SplashPage", ScreenOrientation = ScreenOrientation.Portrait)]
    public class OnboardingActivity : FragmentActivity
    {

        private ViewPager _viewpager;
        private LinearLayout _dotsLayout { get; set; }
        private TextView[] _dots { get; set; }
        private Button _log_in;
        private Button _sign_up;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_onboarding);
            _log_in = FindViewById<Button>(Resource.Id.login);
            _sign_up = FindViewById<Button>(Resource.Id.sign_up);
            // Create your application here
            _viewpager = FindViewById<ViewPager>(Resource.Id.viewPager);
            _viewpager.Adapter = new FragAdapter(SupportFragmentManager);
            _dotsLayout = FindViewById<LinearLayout>(Resource.Id.indicator);

            _viewpager.PageSelected += _viewPager_PageSelected;  //subscribe to viewPager page change
            _log_in.Click += log_in_Click;
            _sign_up.Click += sign_up_Click;
            AddDotsIndicator(0); //draw indicator at start position
        }

        private void sign_up_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
            OverridePendingTransition(0, 0);
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
            OverridePendingTransition(0, 0);
        }

        private void _viewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            AddDotsIndicator(e.Position);
        }

       
        private void AddDotsIndicator(int pos)
        {
            _dots = new TextView[3];
            _dotsLayout.RemoveAllViews();
            for (int i = 0; i < _dots.Length; i++)
            {
                _dots[i] = new TextView(this);
                _dots[i].Text = FromHtml("&#8226").ToString();
                _dots[i].TextSize = 35;
                _dots[i].SetTextColor(Android.Graphics.Color.Rgb(171, 169, 166));// customize your colors
                _dotsLayout.AddView(_dots[i]);
            }
            if (_dots.Length > 0)
                _dots[pos].SetTextColor(Android.Graphics.Color.White); //change indicator color on selected page
        }

        public class FragAdapter : FragmentPagerAdapter
        {

            public FragAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
            {

            }

            public override int Count => 3;

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return new onBoardingFragment1(position);
            }

        }

        public class onBoardingFragment1 : Android.Support.V4.App.Fragment
        {
            private int num;

            public onBoardingFragment1(int num)
            {
                this.num = num;
            }

            public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {

                switch (num)
                {
                    case 0:
                        return inflater.Inflate(Resource.Layout.onboarding1, container, false);
                    case 1:
                        return inflater.Inflate(Resource.Layout.onboarding2, container, false);
                    case 2:
                        return inflater.Inflate(Resource.Layout.onboarding3, container, false);
                    default:
                        break;
                }
                return null;
            }
        }

        public static ISpanned FromHtml(String html)
        {
            if (html == null)
            {
                // return an empty spannable if the html is null
                return new SpannableString("");
            }
#pragma warning disable CS0618 // Type or member is obsolete
            else if (Build.VERSION.SdkInt >= Build.VERSION_CODES.N)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                // FROM_HTML_MODE_LEGACY is the behaviour that was used for versions below android N
                // we are using this flag to give a consistent behaviour
#pragma warning disable CS0618 // Type or member is obsolete
                return Html.FromHtml(html, Html.FromHtmlModeLegacy);
#pragma warning restore CS0618 // Type or member is obsolete
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                return Html.FromHtml(html);
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }
    }
}