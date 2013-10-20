namespace RedBird.Droid.Activities
{
    using Android.App;
    using Android.OS;
    using Android.Views;

    [Activity(Label = "Home", Icon = "@drawable/icon")]
    public class HomeActivity : Activity
    {
        // Fields
        
        // Properties

        // Initialization Methods
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);
            
            ActionBar.DisplayOptions = ActionBarDisplayOptions.ShowHome |
                                  ActionBarDisplayOptions.ShowTitle |
                                  ActionBarDisplayOptions.UseLogo;
            ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
            ActionBar.SetDisplayShowHomeEnabled(true);
        }

        // Private Methods

        // Public Methods
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.main_menu, menu);
            return true;
        }
    }
}

