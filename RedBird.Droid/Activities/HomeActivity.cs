using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace RedBird.Droid.Activities
{
	[Activity(Label = "Home", Icon = "@drawable/icon")]
	public class HomeActivity : Activity
	{
		// Fields

		// Initialization
		protected override void OnCreate(Bundle bundle)
		{
			try
			{
				base.OnCreate(bundle);

				// Create your application here
				SetContentView(Resource.Layout.Home);

				Initialization();
			}
			catch (Exception exception)
			{
				string something = "";
			}
		}

		// Properties

		// Private Methods
		private void Initialization()
		{
			InitializeUserControls();
			InitializeActionBar();
		}

		private void InitializeUserControls()
		{
			
		}

		private void InitializeActionBar()
		{
			ActionBar.DisplayOptions = ActionBarDisplayOptions.ShowHome |
								  ActionBarDisplayOptions.ShowTitle |
								  ActionBarDisplayOptions.UseLogo;
			ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
			ActionBar.SetDisplayShowHomeEnabled(true);
		}

		// Public Methods
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater inflater = MenuInflater;
			inflater.Inflate(Resource.Menu.main_menu, menu);
			return true;
		}
	}
}