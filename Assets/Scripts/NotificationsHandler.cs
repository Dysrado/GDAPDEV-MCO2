using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationsHandler : MonoBehaviour
{
    [SerializeField] string notif_title = "Hey you!";

    [SerializeField] string notif_message = ":>";

    private void Awake()
    {
        BuildDefaultNotificationChannel();
    }

    private void BuildDefaultNotificationChannel()
    {
        string channel_id = "default";

        string title = "Defaul Channel";

        Importance importance = Importance.Default;

        string description = "Default Channel for this game";

        AndroidNotificationChannel defaultChannel = new AndroidNotificationChannel(channel_id, title, description, importance);

        AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);
    }

    public void SendNotif()
    {
        System.DateTime fireTime = System.DateTime.Now.AddSeconds(10);

        AndroidNotification notif = new AndroidNotification(notif_title, notif_message, fireTime);

        AndroidNotificationCenter.SendNotification(notif, "default");
    }
}
