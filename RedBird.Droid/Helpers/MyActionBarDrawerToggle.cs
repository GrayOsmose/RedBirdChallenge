using System;
using Android.App;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;

namespace RedBird.Droid.Helpers
{
    public class ActionBarDrawerEventArgs : EventArgs
    {
        public View DrawerView { get; set; }
        public float SlideOffset { get; set; }
        public int NewState { get; set; }
    }

    public class MyActionBarDrawerToggle : ActionBarDrawerToggle
    {
        public MyActionBarDrawerToggle(Activity activity,
                                       DrawerLayout drawerLayout,
                                       int drawerImageRes,
                                       int openDrawerContentDescRes,
                                       int closeDrawerContentDescRes)
            : base(activity,
                  drawerLayout,
                  drawerImageRes,
                  openDrawerContentDescRes,
                  closeDrawerContentDescRes)
        {
            
        }

		public event EventHandler<ActionBarDrawerEventArgs> DrawerClosed;
		public event EventHandler<ActionBarDrawerEventArgs> DrawerOpened;
		public event EventHandler<ActionBarDrawerEventArgs> DrawerSlide;
		public event EventHandler<ActionBarDrawerEventArgs> DrawerStateChanged;

        public override void OnDrawerClosed(View drawerView)
        {
            if (null != DrawerClosed)
                DrawerClosed(this, new ActionBarDrawerEventArgs { DrawerView = drawerView });
            base.OnDrawerClosed(drawerView);
        }

        public override void OnDrawerOpened(View drawerView)
        {
            if (null != DrawerOpened)
                DrawerOpened(this, new ActionBarDrawerEventArgs { DrawerView = drawerView });
            base.OnDrawerOpened(drawerView);
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            if (null != DrawerSlide)
                DrawerSlide(this, new ActionBarDrawerEventArgs
                {
                    DrawerView = drawerView,
                    SlideOffset = slideOffset
                });
            base.OnDrawerSlide(drawerView, slideOffset);
        }

        public override void OnDrawerStateChanged(int newState)
        {
            if (null != DrawerStateChanged)
                DrawerStateChanged(this, new ActionBarDrawerEventArgs
                {
                    NewState = newState
                });
            base.OnDrawerStateChanged(newState);
        }
    }
}