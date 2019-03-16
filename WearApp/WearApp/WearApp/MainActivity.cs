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

namespace WearApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity        
    {
        public int FORGOT_PHONE_NOTIFICATION_ID = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);              
            SetContentView(Resource.Layout.activity_main);

            Button btnSoundTrigger = FindViewById<Button>(Resource.Id.SoundTrigger);
            Button btnFlashTrigger = FindViewById<Button>(Resource.Id.FlashTrigger);
            Button btnVibTrigger = FindViewById<Button>(Resource.Id.VibTrigger);
            Communicator cm = new Communicator(this);

            btnSoundTrigger.Click += delegate
            {                                          
                cm.SendMessage("option1");             
            };
            btnFlashTrigger.Click += delegate
            {
                cm.SendMessage("option2");              
            };
            btnVibTrigger.Click += delegate
            {
                cm.SendMessage("option3");                
            };
            SetAmbientEnabled();
        }
        private void Cm_DataReceived(DataMap obj)
        {
            throw new NotImplementedException();
        }
        public void OnConnected(Bundle connectionHint)
        {
            try
            {
                //google_api_client.BlockingConnect(CONNECTION_TIME_OUT_MS, TimeUnit.Milliseconds);
              // RunningOnBackground();
            }
            catch (Exception ex)
            {

                throw;
            }
        } 
        public void OnConnectionSuspended(int cause)
        {
         
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
           
        }
    }
}


