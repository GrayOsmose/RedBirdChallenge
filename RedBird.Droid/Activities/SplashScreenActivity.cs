namespace RedBird.Droid.Activities
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using System.Threading;

    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            App.Start();

            // Create your application here
            Thread.Sleep(600); // Simulate a long loading process on app startup.
            StartActivity(typeof(HomeFragmentActivity));
        }
    }
}