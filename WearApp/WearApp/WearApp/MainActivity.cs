using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Wearable.Activity;
using Java.Interop;
using Android.Views.Animations;
using Android.Text;
using Android.Text.Style;
using Android.Gms.Common.Apis;
using Android.Gms.Wearable;
using Android.Gms.Common;
using Android.Util;
using Java.Util.Concurrent;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Auth.Api;
using System.Threading.Tasks;
using System.Collections.Generic;
using Android.Graphics;
using Android.Support.Wearable.View.Drawer;
using static System.Collections.Specialized.BitVector32;
using Android.Graphics.Drawables;
using Java.Lang;
using Android.Support.Annotation;

namespace WearApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity        
    {
        public int FORGOT_PHONE_NOTIFICATION_ID = 1;
        #region navigation
        private Section DEFAULT_SECTION = Section.Sun;
        private WearableNavigationDrawer mWearableNavigationDrawer;
        private WearableActionDrawer mWearableActionDrawer;
        #endregion
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);              
            SetContentView(Resource.Layout.activity_main2);

            #region NVD
            mWearableNavigationDrawer = (WearableNavigationDrawer)FindViewById(Resource.Id.top_navigation_drawer);
            //mWearableNavigationDrawer.SetAdapter(new NavigationAdapter(this, mWearableNavigationDrawer, mWearableActionDrawer));
           
            #endregion
            SectionFragment f = new SectionFragment();
            Communicator objCommunicator = new Communicator(this);

        SectionFragment sectionFragment = f.GetSection(DEFAULT_SECTION);
            var sFFB = this.FragmentManager.BeginTransaction();
            sFFB.Replace(Resource.Id.fragment_container, sectionFragment);
            sFFB.Commit();

            mWearableActionDrawer = (WearableActionDrawer)FindViewById(Resource.Id.bottom_action_drawer);
            mWearableNavigationDrawer.SetAdapter(new NavigationAdapter(this, this.FragmentManager, mWearableNavigationDrawer, mWearableActionDrawer,objCommunicator));
            mWearableActionDrawer.MenuItemClick += (m, arg) =>
            {
                mWearableActionDrawer.CloseDrawer();
                switch (arg.Item.ItemId)
                {
                    case Resource.Id.action_edit:
                        Toast.MakeText(this, Resource.String.action_edit_todo, ToastLength.Short).Show();
                        //return true;
                        break;
                    case Resource.Id.action_share:
                        Toast.MakeText(this, Resource.String.action_share_todo, ToastLength.Short).Show();
                        // return true;
                        break;
                }
            
                // return false;
            };



        Communicator cm = new Communicator(this);

            //btnSoundTrigger.Click += delegate
            //{                                          
            //    cm.SendMessage("option1");             
            //};
            //btnFlashTrigger.Click += delegate
            //{
            //    cm.SendMessage("option2");              
            //};
            //btnVibTrigger.Click += delegate
            //{
            //    cm.SendMessage("option3");                
            //};
            SetAmbientEnabled();
        }
        public bool OnMenuItemClick(IMenuItem menuItem)
        {
            mWearableActionDrawer.CloseDrawer();
            switch (menuItem.ItemId)
            {
                case Resource.Id.action_edit:
                    Toast.MakeText(this, Resource.String.action_edit_todo, ToastLength.Short).Show();
                    return true;
                case Resource.Id.action_share:
                    Toast.MakeText(this, Resource.String.action_share_todo, ToastLength.Short).Show();
                    return true;
            }
            return false;
        }
        private void Cm_DataReceived(DataMap obj)
        {
            
        }
        public void OnConnected(Bundle connectionHint)
        {
          
        } 
        public void OnConnectionSuspended(int cause)
        {
         
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
           
        }
    }


   
   
}


