using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using TheAndroidPoc.TheView;
using Android.Views;
using Android.Content;
using TheAndroidPoc.Fragments;
using System;


namespace TheAndroidPoc
{
    [Activity(Theme = "@style/SplashPage")]
    public class CentralActivity : AppCompatActivity
    {

        BottomNavigationView bottomNavigation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_central);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            //bottomNavigation.SelectedItemId = Resource.Id.menu_home;

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.menu_home);

        }


        

        void LoadFragment(int id)
        {
            bool exists = SupportFragmentManager.PopBackStackImmediate(id.ToString(), 0);
            Android.Support.V4.App.Fragment fragment = null;
           
            switch (id)
            {
                case Resource.Id.menu_home:
                    if(!exists && SupportFragmentManager.FindFragmentByTag(Resource.Id.menu_home.ToString()) == null )
                        fragment = HomeFragment.NewInstance();
                    break;
                case Resource.Id.menu_discover:
                    if(!exists && SupportFragmentManager.FindFragmentByTag(Resource.Id.menu_discover.ToString()) == null)
                        fragment = DiscoverFragment.NewInstance();
                    break;
                case Resource.Id.menu_person:
                    if(!exists && SupportFragmentManager.FindFragmentByTag(Resource.Id.menu_person.ToString()) == null)
                        fragment = PersonFragment.NewInstance();
                    break;
            }

            if (fragment == null)
                return;
            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment, id.ToString())
                .AddToBackStack(id.ToString())
                .Commit();
        }

        public override void OnBackPressed()
        {
            int count = SupportFragmentManager.BackStackEntryCount;

            if (count == 1)
            {
                Finish();
                //additional code
            }
            else
            {
                base.OnBackPressed();
                var f = SupportFragmentManager.FindFragmentById(Resource.Id.content_frame);
                int tag = Int32.Parse(f.Tag);
                bottomNavigation.SelectedItemId = tag;
            }
            OverridePendingTransition(0, 0);

        }

        private void Update_BottomNavigation_NavigationItemSelected(object sender, EventArgs e)
        {
           var f = SupportFragmentManager.FindFragmentById(Resource.Id.content_frame);
            int tag = Int32.Parse(f.Tag);
            switch (tag)
            {
                case Resource.Id.menu_home:
                    bottomNavigation.SelectedItemId = Resource.Id.menu_home;
                    break;
                case Resource.Id.menu_discover:
                    bottomNavigation.SelectedItemId = Resource.Id.menu_discover;
                    break;
                case Resource.Id.menu_person:
                    bottomNavigation.SelectedItemId = Resource.Id.menu_person;
                    break;
            }
                

        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}