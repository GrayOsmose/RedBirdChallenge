using System;
using System.Collections.ObjectModel;
using Android.Widget;
using Core.Model.Models;

namespace RedBird.Droid.Activities
{
    using Android.App;
    using Android.OS;
    using Android.Views;

    [Activity(Label = "Home", Icon = "@drawable/icon")]
    public class HomeActivity : ListActivity
    {
        // Fields
        private ObservableCollection<Tweet> foTweet;
        private int fLastNumber;
        private Button fButtonUpdate;
        // private ListView fListViewTweets; 
        
        // Properties
        public Button pButtonUpdate
        {
            get
            {
                return fButtonUpdate ??
                       (fButtonUpdate = FindViewById<Button>(Resource.Id.buttonUpdate));
            }
        }

        /*
        public ListView pListViewTweets
        {
            get
            {
                return fListViewTweets ??
                       (fListViewTweets = FindViewById<ListView>(Resource.Id.ListViewTweets));
            }
        }
        */

        // Initialization Methods
        protected override void OnCreate(Bundle bundle)
        {
            try
            {

                base.OnCreate(bundle);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Home);

                Initialization();
            }
            catch (Exception mException)
            {
                var index = 0;
            }
        }

        private void Initialization()
        {
            InitializeUserControls();
            InitializeActionBar();
            InitializeListData();
        }

        private void InitializeUserControls()
        {
            pButtonUpdate.Click += pButtonUpdate_OnClick;
            // fListViewTweets.ItemClick += OnListItemClick;
        }

        private void pButtonUpdate_OnClick(object sender, EventArgs eventArgs)
        {
            // ToDo : load more tweets and all
        }

        private void InitializeListData()
        {
            bool mIsLast;

            foTweet = new ObservableCollection<Tweet>(Core.Model.Provider.ModelProvider.Instance.pPropvider.GetTweets(out mIsLast, out fLastNumber));
            
            // pListViewTweets.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, foTweet);
            ListAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, foTweet);

            if (mIsLast)
            {
                HideUpdateButton();
            }
        }

        private void InitializeActionBar()
        {
            ActionBar.DisplayOptions = ActionBarDisplayOptions.ShowHome |
                                  ActionBarDisplayOptions.ShowTitle |
                                  ActionBarDisplayOptions.UseLogo;
            ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
            ActionBar.SetDisplayShowHomeEnabled(true);
        }

        // Private Methods
        private void HideUpdateButton()
        {
            fButtonUpdate.Visibility = ViewStates.Gone;
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
        }

        protected override void OnListItemClick(ListView inListView, View inView, int inPosition, long inId)
        {
            // ToDo : transfer to fragment and stuff
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

