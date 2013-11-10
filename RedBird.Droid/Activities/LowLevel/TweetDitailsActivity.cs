namespace RedBird.Droid.Activities.LowLevel
{
	using Android.App;
	using Android.OS;

	[Activity(Label = "Tweet", Theme = "@android:style/Theme.Holo.Light", Icon = "@drawable/ic_launcher")]
	public class TweetDitailsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.fragment_tweet_details);
		}
	}
}