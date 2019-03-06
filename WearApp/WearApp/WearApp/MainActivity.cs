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

namespace WearApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity        
    {   
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
                cm.SendMessage("alarm");
             //   cm.DataReceived += Cm_DataReceived; 
            };
            btnFlashTrigger.Click += delegate
            {
                cm.SendMessage("flash");
               // cm.DataReceived += Cm_DataReceived;
            };
            btnVibTrigger.Click += delegate
            {
                cm.SendMessage("vib");
                //cm.DataReceived += Cm_DataReceived;
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


