using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using RedBird.Droid.Fragments.Home;
using RedBird.Droid.Helpers;

namespace RedBird.Droid.Activities
{
	[Activity(Label = "Home", LaunchMode = LaunchMode.SingleTop, Theme = "@android:style/Theme.Holo.Light", Icon = "@drawable/ic_launcher")]
	public class HomeFragmentActivity : FragmentActivity
	{
		#region Fields

		private string fDrawerTitle;
		private string fTitle;

		private bool fIsDualPane = false;

		private MyActionBarDrawerToggle fDrawerToggle;

		private DrawerLayout fDrawer;
		private ListView fDrawerListLeft;
		private ListView fDrawerListRight;

		private static readonly string[] Sections = new[]
            {
                "News", "Friends", "Profile"
            };

		#endregion

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_home);

			Initialization(bundle);
		}

		protected override void OnPostCreate(Bundle savedInstanceState)
		{
			base.OnPostCreate(savedInstanceState);
			fDrawerToggle.SyncState();
		}

		public override void OnConfigurationChanged(Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			fDrawerToggle.OnConfigurationChanged(newConfig);
		}

		private void Initialization(Bundle bundle)
		{
			InitializationDrawer();
			InitializeFirstFragment(bundle);
			InitializationActionBar();
		}

		private void InitializationActionBar()
		{
			ActionBar.SetDisplayHomeAsUpEnabled(true);
			ActionBar.SetHomeButtonEnabled(true);
		}

		private void InitializationDrawer()
		{
			/*
			fDrawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			fDrawerListLeft = FindViewById<ListView>(Resource.Id.left_drawer);

			fDrawerListLeft.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);

			fDrawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);
			*/

			fTitle = fDrawerTitle = Title;

			fDrawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			fDrawerListLeft = FindViewById<ListView>(Resource.Id.left_drawer);

			fDrawerListLeft.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);

			fDrawerListLeft.ItemClick += (sender, args) => ListItemClickedLeft(args.Position);

			fDrawerListRight = FindViewById<ListView>(Resource.Id.right_drawer);

			fDrawerListRight.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);

			fDrawerListRight.ItemClick += (sender, args) => ListItemClickedRight(args.Position);

			fDrawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);

			//DrawerToggle is the animation that happens with the indicator next to the actionbar
			fDrawerToggle = new MyActionBarDrawerToggle(this,
														fDrawer,
														Resource.Drawable.ic_drawer_light,
														Resource.String.drawer_open,
														Resource.String.drawer_close);

			//Display the current fragments title and update the options menu
			fDrawerToggle.DrawerClosed += (o, args) =>
			{
				ActionBar.Title = fTitle;
				InvalidateOptionsMenu();
			};

			//Display the drawer title and update the options menu
			fDrawerToggle.DrawerOpened += (o, args) =>
			{
				ActionBar.Title = fDrawerTitle;
				InvalidateOptionsMenu();
			};

			//Set the drawer lister to be the toggle.
			fDrawer.SetDrawerListener(fDrawerToggle);
		}

		private void InitializeFirstFragment(Bundle bundle)
		{
			if (bundle != null)
			{
				return;
			}

			SupportFragmentManager.BeginTransaction()
				.Replace(Resource.Id.frame_content, new TweetListFragment())
				.Commit();

			var detailsFrame = FindViewById<View>(Resource.Id.frame_details);
			fIsDualPane = detailsFrame != null && detailsFrame.Visibility == ViewStates.Visible;

			if (fIsDualPane)
			{
				SupportFragmentManager.BeginTransaction()
				.Replace(Resource.Id.frame_details, new TweetDetailsFragment())
				.Commit();
			}
		}

		private void ListItemClickedLeft(int position)
		{
			fDrawer.CloseDrawer(fDrawerListLeft);
		}

		private void ListItemClickedRight(int position)
		{
			fDrawer.CloseDrawer(fDrawerListRight);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_main, menu);

			// return base.OnCreateOptionsMenu(menu);

			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (fDrawerToggle.OnOptionsItemSelected(item))
				return true;

			return base.OnOptionsItemSelected(item);
		}

		public override bool OnPrepareOptionsMenu(IMenu menu)
		{
			var drawerOpen = fDrawer.IsDrawerOpen(fDrawerListLeft);
			//when open don't show anything
			for (int i = 0; i < menu.Size(); i++)
				menu.GetItem(i).SetVisible(!drawerOpen);

			return base.OnPrepareOptionsMenu(menu);
		}
	}
}