using RedBird.Droid.Activities.LowLevel;

namespace RedBird.Droid.Fragments.Home
{
	using Android.Content;
	using Android.OS;
	using Android.Views;
	using Android.Widget;
	using Core.Model.Models;
	using System.Collections.ObjectModel;

	public class TweetListFragment : Android.Support.V4.App.ListFragment
	{
		// Fields
		private ObservableCollection<Tweet> foTweet;
		private int fLastNumber;

		private bool fIsDualPane = false;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here

		}

		// Private Methods
		private void ShowTweet(int inPosition)
		{
			// var detailsFrame = Activity.FindViewById<View>(Resource.Id.tweet_details);
			
			if (fIsDualPane)
			{
				// We can display everything in place with fragments.
				// Have the list highlight this item and show the data.
				ListView.SetItemChecked(inPosition, true);
				// Check what fragment is shown, replace if needed.
				var details = FragmentManager.FindFragmentById(Resource.Id.frame_details) as TweetDetailsFragment;

				if (details == null || details.TweetPosition != inPosition)
				{
					// Make new fragment to show this selection.
					details = TweetDetailsFragment.NewInstance(inPosition);
					// Execute a transaction, replacing any existing
					// fragment with this one inside the frame.
					var ft = FragmentManager.BeginTransaction();
					ft.Replace(Resource.Id.frame_details, details);
					// ft.SetTransition(FragmentTransaction.TransitFragmentFade);
					ft.Commit();
				}
			}
			else
			{
				// Otherwise we need to launch a new Activity to display
				// the dialog fragment with selected text.

				var intent = new Intent();
				intent.SetClass(Activity, typeof(TweetDitailsActivity));
				intent.PutExtra("tweet", inPosition);
				StartActivity(intent);
			}
		}

		// Public Methods
		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			bool mIsLast;
			foTweet = new ObservableCollection<Tweet>(Core.Model.Provider.ModelProvider.Instance.pPropvider.GetTweets(out mIsLast, out fLastNumber));

			ListAdapter = new ArrayAdapter(Activity, Android.Resource.Layout.SimpleListItem1, foTweet);

			var detailsFrame = Activity.FindViewById<View>(Resource.Id.frame_details);
			fIsDualPane = detailsFrame != null && detailsFrame.Visibility == ViewStates.Visible;

			if (fIsDualPane)
			{
				ListView.ChoiceMode = ChoiceMode.Single;
			}
		}

		public override void OnListItemClick(ListView inListView, View inView, int inPosition, long inId)
		{
			base.OnListItemClick(inListView, inView, inPosition, inId);

			ShowTweet(inPosition);
		}
	}
}