using Android.App;
using Android.OS;

namespace RedBird.Droid.Activities.Fragments.Home
{
	public class TweetDescriptionFragment : Fragment
	{
		// Fields

		// Properties
		public int TweetPosition { get; set; }

		// Public Methods
		public static TweetDescriptionFragment NewInstance(int playId)
		{
			var detailsFrag = new TweetDescriptionFragment { Arguments = new Bundle() };
			// detailsFrag.Arguments.PutInt("current_play_id", playId);
			return detailsFrag;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}
	}
}