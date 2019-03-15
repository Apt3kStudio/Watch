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


            Notification.Builder notificationBuilder = new Notification.Builder(this, "")
                    .SetContentTitle("Forgetting Something?")
                    .SetContentText("You may have left your phone behind.")
                    //.SetVibrate(new long[] { 0, 200 })
                    .SetSmallIcon(Resource.Drawable.ic_add_alert_black_18dp)
                    .SetLocalOnly(true);
            //.SetPriority((int)NotificationPriority.Max);
            Notification card = notificationBuilder.Build();
            ((NotificationManager)GetSystemService(NotificationService))
                .Notify(FORGOT_PHONE_NOTIFICATION_ID, card);

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

                cm.SendMessage("option");
                //NotificationManager notificationManager = (NotificationManager)GetSystemService(NotificationService);
                //Notification notification = new Notification.Builder(this)
                //        .SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Mipmap.ic_launcher))
                //        .SetSmallIcon(Resource.Mipmap.ic_launcher)
                //        .SetContentTitle("title")
                //        .SetContentText("contentText")
                //        //.SetPriority(Notification.PriorityHigh)
                //        //.SetContentIntent(pendingIntent)
                //        .SetAutoCancel(true)
                //        .Build();
                //notificationManager.Notify(1, notification);


                // Notification.Builder noti1 = new Notification.Builder(this)
                //// Notification noti = new Notification.Builder(this,"")
                //  .SetContentTitle("Forgetting Something?")
                //   .SetContentText("You may have left your phone behind.")
                // .SetContentText("subject")
                // .SetSmallIcon(Resource.Drawable.ic_add_alert_black_18dp)                    
                //   .SetLocalOnly(true)
                // //.SetPriority((int)NotificationPriority.Max);
                // //.SetLargeIcon(Resource.Drawable.Icon)
                // .Build();
                //Notification.Builder notificationBuilder = new Notification.Builder(this, "")
                //     .SetContentTitle("Forgetting Something?")
                //     .SetContentText("You may have left your phone behind.")
                //     //.SetVibrate(new long[] { 0, 200 })
                //     .SetSmallIcon(Resource.Drawable.ic_add_alert_black_18dp)
                //     .SetLocalOnly(true);
                //     //.SetPriority((int)NotificationPriority.Max);
                //Notification card = notificationBuilder.Build();
                //((NotificationManager)GetSystemService(NotificationService))
                //    .Notify(FORGOT_PHONE_NOTIFICATION_ID, card);
                //Notification card = noti.Build();
                //((NotificationManager)GetSystemService(NotificationService))
                //    .Notify(FORGOT_PHONE_NOTIFICATION_ID, noti);


                //cm.SendMessage("vib");
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


