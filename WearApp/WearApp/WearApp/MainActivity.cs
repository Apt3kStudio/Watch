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

namespace WearApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        const int FIND_PHONE_NOTIFICATION_ID = 2;
        private static Notification.Builder notification;
        const string TAG = "ExampleFindPhoneApp";
        const string FIELD_ALARM_ON = "alarm_on";
        const string PATH_SOUND_ALARM = "/sound_alarm";

        public const string ACTION_TOGGLE_ALARM = "action_toggle_alarm";
        public const string ACTION_CANCEL_ALARM = "action_alarm_off";

        const int CONNECTION_TIME_OUT_MS = 100;
        private GoogleApiClient google_api_client;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
               .RequestScopes(new Scope(Scopes.DriveAppfolder))
           .Build();


           
          //.addApi(Drive.API)
          //.addApi(Auth.GOOGLE_SIGN_IN_API, gso)
         
            google_api_client = new GoogleApiClient.Builder(this)
                .addApi(Drive.API)
                .addApi(Auth.GOOGLE_SIGN_IN_API, gso)
                //.AddApi(WearableClass.API,gso)
                .AddConnectionCallbacks(this)
                .AddOnConnectionFailedListener(this)
                .Build();
           
            SetContentView(Resource.Layout.activity_main);
            Button btnSoundTrigger = FindViewById<Button>(Resource.Id.SoundTrigger);
            btnSoundTrigger.Click += delegate
            {
                google_api_client.Connect();
               
                //TriggerSound();
            };


            //test
            SetAmbientEnabled();
        }      
        public void test()
        {
            try
            {
               
               
                //google_api_client = new GoogleApiClient.Builder(this)
                //  .AddApi(WearableClass.API)
                //  .AddConnectionCallbacks(this)
                //  .AddOnConnectionFailedListener(this)
                //  .Build();


                google_api_client.BlockingConnect(CONNECTION_TIME_OUT_MS, TimeUnit.Milliseconds);
            }                    
            catch (Exception ex)
            {
                var message = ex.Message;
                ///throw;
            }

            //if (Log.IsLoggable(TAG, LogPriority.Verbose))
            //    Log.Verbose(TAG, "FindPhoneService.OnHandleEvent");

            //if (google_api_client.IsConnected)
            //{
            //    bool alarmOn = false;
            //    if (intent.Action == ACTION_TOGGLE_ALARM)
            //    {
            //        var result = WearableClass.DataApi.GetDataItems(google_api_client).Await().JavaCast<DataItemBuffer>();
            //        if (result.Status.IsSuccess)
            //        {
            //            if (result.Count == 1)
            //            {
            //                alarmOn = DataMap.FromByteArray((result.Get(0).JavaCast<IDataItem>()).GetData()).GetBoolean(FIELD_ALARM_ON, false);
            //            }
            //            else
            //            {
            //                Log.Error(TAG, "Unexpected number of DataItems found.\n" +
            //                    "\tExpected: 1\n" +
            //                    "\tActual: " + result.Count);
            //            }
            //        }
            //        else if (Log.IsLoggable(TAG, LogPriority.Debug))
            //        {
            //            Log.Debug(TAG, "OnHandleIntent: failed to get current alarm state");
            //        }

            //        result.Close();
            //        alarmOn = !alarmOn;
            //        string notificationText = alarmOn ? GetString(Resource.String.turn_alarm_on) : GetString(Resource.String.turn_alarm_off);
            //        MainActivity.UpdateNotification(this, notificationText);
            //    }
            try
            {

            
                var putDataMapRequest = PutDataMapRequest.Create(PATH_SOUND_ALARM);
                putDataMapRequest.DataMap.PutBoolean(FIELD_ALARM_ON, true);
                WearableClass.DataApi.PutDataItem(google_api_client, putDataMapRequest.AsPutDataRequest()).Await();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                ///throw;
            }
            //}
            // else
            //{
            //   Log.Error(TAG, "Failed to toggle alarm on phone - Client disconnected from Google Play Services");
            // }
            google_api_client.Disconnect();
        }

        public bool TriggerSound()
        {
            var title = new SpannableString("Find My Phone");
            title.SetSpan(new RelativeSizeSpan(0.85f), 0, title.Length(), SpanTypes.PointMark);

            Notification.Action NotificationAction = GetActionIntent(FindPhoneService.ACTION_TOGGLE_ALARM);
            PendingIntent cancel_alarm_intent = GetCancelledActionIntent();
            Notification_Alarm_Sound(NotificationAction, cancel_alarm_intent, title, this);

            return true;
        }

        private PendingIntent GetCancelledActionIntent()
        {
            var IntentCancelAlarmOperation = new Intent(this, typeof(FindPhoneService));
            IntentCancelAlarmOperation.SetAction(FindPhoneService.ACTION_CANCEL_ALARM);
            var cancel_alarm_intent = PendingIntent.GetService(this, 0, IntentCancelAlarmOperation, PendingIntentFlags.CancelCurrent);
            return cancel_alarm_intent;
        }

        private Notification.Action GetActionIntent(string ACTION_TOGGLE_ALARM)
        {
            var IntentToggleAlarm = new Intent(this, typeof(FindPhoneService));
            IntentToggleAlarm.SetAction(ACTION_TOGGLE_ALARM);
            var pendingIntent = PendingIntent.GetService(this, 0, IntentToggleAlarm, PendingIntentFlags.CancelCurrent);
            Android.App.Notification.Action alarm_actionNotification = new Android.App.Notification.Action(Resource.Drawable.ic_add_alert_black_18dp, "", pendingIntent);
            return alarm_actionNotification;
        }

        private void Notification_Alarm_Sound(Notification.Action alarm_action, PendingIntent cancel_alarm_intent, SpannableString title, MainActivity mainActivity)
        {
            Context ctxt = this;
            try
            {
                Notification.WearableExtender nWearable = new Notification.WearableExtender();
                nWearable.AddAction(alarm_action);
               
                nWearable.SetContentAction(0);
                nWearable.SetHintHideIcon(true);

                notification = new Notification.Builder(this, "sdsdsda")
                .SetContentTitle(title)
                .SetContentText("Tap to sound an alarm on phone")
                .SetSmallIcon(Resource.Drawable.ic_add_alert_black_18dp)
                .SetDeleteIntent(cancel_alarm_intent)
                .Extend(new Notification.WearableExtender());
                #region This is custom 
                    Intent nIntentService = new Intent();
                    FindPhoneService fps = new FindPhoneService();
                #endregion
                fps.sendData(mainActivity);
                
                ((NotificationManager)GetSystemService(NotificationService))
                .Notify(FIND_PHONE_NOTIFICATION_ID, notification.Build());
            }
            catch (Exception e)
            {
                var errorMessage = e.Message;
                throw;
            }
        }

        public static void UpdateNotification(Context context, string notificationText)
        {
            notification.SetContentText(notificationText);
            ((NotificationManager)context.GetSystemService(NotificationService))
                .Notify(FIND_PHONE_NOTIFICATION_ID, notification.Build());
        }

        public void OnConnected(Bundle connectionHint)
        {
            test();
        }

        public void OnConnectionSuspended(int cause)
        {
            throw new NotImplementedException();
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            throw new NotImplementedException();
        }
    }
}


