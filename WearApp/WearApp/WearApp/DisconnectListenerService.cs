﻿using System;
using Android.App;
using Android.Content;
using Android.Gms.Wearable;

namespace WearApp
{
        [Service]
        [IntentFilter(new string[] { "com.google.android.gms.wearable.BIND_LISTENER" })]
        public class DisconnectListenerService : WearableListenerService
        {
            const string TAG = "ExampleFindPhoneApp";

            const int FORGOT_PHONE_NOTIFICATION_ID = 1;

            public void OnPeerDisconnected(Context context)
            {
            Notification.Builder notificationBuilder = new Notification.Builder(context, "")
                .SetContentTitle("Forgetting Something?")
                .SetContentText("You may have left your phone behind.")
                //.SetVibrate(new long[] { 0, 200 })
                .SetSmallIcon(Resource.Drawable.ic_add_alert_black_18dp)
                .SetLocalOnly(true);
                    //.SetPriority((int)NotificationPriority.Max);
                Notification card = notificationBuilder.Build();
                ((NotificationManager)GetSystemService(NotificationService))
                    .Notify(FORGOT_PHONE_NOTIFICATION_ID, card);
            }

            public override void OnPeerConnected(INode p0)
            {
                ((NotificationManager)GetSystemService(NotificationService))
                    .Cancel(FORGOT_PHONE_NOTIFICATION_ID);
            }
        }
}

