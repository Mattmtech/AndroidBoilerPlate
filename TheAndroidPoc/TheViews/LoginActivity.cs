using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using TheAndroidPoc.TheView;

namespace TheAndroidPoc
{
    [Activity(Theme = "@style/SplashPage")]
    public class LoginActivity : AppCompatActivity
    {
        private Button _log_in_attempt;
        private EditText _pw;
        private EditText _user;
        private TextView _messages;
        private int _pw_length = 0;
        private int _user_length = 0;
        private string _this_pw;
        private string _this_user;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);
            _user = FindViewById<EditText>(Resource.Id.login_username);
            _pw = FindViewById<EditText>(Resource.Id.login_pass);
            _messages = FindViewById<TextView>(Resource.Id.login_messages);
            _log_in_attempt = FindViewById<Button>(Resource.Id.login_attempt);
            _log_in_attempt.Enabled = false;
            _log_in_attempt.Click += log_in_attempt_Click;
            _user.TextChanged += _user_text_changed;
            _pw.TextChanged += _pw_text_changed;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void _user_text_changed(object sender, Android.Text.TextChangedEventArgs e)
        {
            _user_length = e.AfterCount;
            _this_user = e.Text.ToString();
            if (_user_length > 0 && _pw_length > 0)//TODO: add regex to restrict certain characters
            {
                _log_in_attempt.Enabled = true;
            }

        }
        private void _pw_text_changed(object sender, Android.Text.TextChangedEventArgs e)
        {
            _pw_length = e.AfterCount;
            _this_pw = e.Text.ToString();
            if (_user_length > 0 && _pw_length > 0)//TODO: add regex to restrict certain characters
            {
                _log_in_attempt.Enabled = true;
            }

        }

        private void log_in_attempt_Click(object sender, EventArgs e)
        {
            //next in line-> adding red text and having that showup under edit text when button is clicked
            User user = new User(_this_user, _this_pw);
            _messages.Text = "looks like that aint it chief";
            StartActivity(typeof(CentralActivity));
            Finish();
            OverridePendingTransition(0, 0);


            //TODO:SALT the user PW before sending, (add random characters to beginning / end of pw)
            //PEPPER -> set of random possible "additives"(random characters) and randomly use it when storing pw for first time
            //next time somone tries to login grab their input pw add salt to predefined locations
            //then check through each pepper at predefined pepper location
        }
    }
}