namespace RedBird.Droid.Fragments.Home
{
	using Android.Graphics;
	using Android.OS;
	using Android.Views;
	using System;

	public class TweetDetailsFragment : Android.Support.V4.App.Fragment
	{
		// Fields

		// Properties
		public int TweetPosition { get; set; }

		// Public Methods
		public static TweetDetailsFragment NewInstance(int playId)
		{
			var detailsFrag = new TweetDetailsFragment { Arguments = new Bundle() };
			
			// detailsFrag.Arguments.PutInt("current_play_id", playId);

			return detailsFrag;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// ToDo : bundle load

		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.fragment_tweet_details, null);

			return view;
		}
	}
}