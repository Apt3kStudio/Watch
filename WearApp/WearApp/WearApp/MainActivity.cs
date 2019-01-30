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

namespace WearApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity
    {
       //TextView textView;
      //  int count = 1;

        #region Send Data variables
      //  const int FIND_PHONE_NOTIFICATION_ID = 2;
      //  private static Notification.Builder notification;
        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);

          // Button button = FindViewById<Button>(Resource.Id.click_button);
          //  TextView text = FindViewById<TextView>(Resource.Id.result);

            //button.Click += delegate {
            //    text.Text = string.Format("{0} clicks!", count++);
            //};


            #region Sesnd Data config 
            //var toggle_alarm_operation = new Intent (this, typeof(FindPhoneService));           
			//toggle_alarm_operation.SetAction(FindPhoneService.ACTION_TOGGLE_ALARM);
			//var toggle_alarm_intent = PendingIntent.GetService (this, 0, toggle_alarm_operation, PendingIntentFlags.CancelCurrent);
			//Android.App.Notification.Action alarm_action = new Android.App.Notification.Action (Resource.Drawable.round_add_alert_black_18dp, "", toggle_alarm_intent);
			//var cancel_alarm_operation = new Intent (this, typeof(FindPhoneService));
			//cancel_alarm_operation.SetAction (FindPhoneService.ACTION_CANCEL_ALARM);
			//var cancel_alarm_intent = PendingIntent.GetService (this, 0, cancel_alarm_operation, PendingIntentFlags.CancelCurrent);
            //var title = new SpannableString("Find My Phone");
            //title.SetSpan(new RelativeSizeSpan(0.85f), 0, title.Length(), SpanTypes.PointMark);
            //notification = new Notification.Builder (this)
            //.SetContentTitle (title)
			//	.SetContentText ("Tap to sound an alarm on phone")
			//	.SetSmallIcon (Resource.Drawable.round_add_alert_black_18dp)
			//	.SetVibrate (new long[]{ 0, 50 })
			//	.SetDeleteIntent (cancel_alarm_intent)
			//	.Extend (new Notification.WearableExtender ()
			//		.AddAction (alarm_action)
			//		.SetContentAction (0)
			//		.SetHintHideIcon (true))
			//	.SetLocalOnly (true)
			//	.SetPriority ((int)NotificationPriority.Max);
			//((NotificationManager)GetSystemService (NotificationService))
			//	.Notify (FIND_PHONE_NOTIFICATION_ID, notification.Build ());

			//Finish ();
            #endregion

        }
        #region send data

        //public static void UpdateNotification(Context context, string notificationText)
        //{
        //    notification.SetContentText(notificationText);
        //    ((NotificationManager)context.GetSystemService(NotificationService))
        //        .Notify(FIND_PHONE_NOTIFICATION_ID, notification.Build());
        //}
        #endregion
    }
}


