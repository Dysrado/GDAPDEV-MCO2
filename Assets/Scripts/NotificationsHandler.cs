using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Notifications.Android;

public class NotificationsHandler : MonoBehaviour
{
    [SerializeField] string notif_title = "Hey you!";

    [SerializeField] string notif_message = ":>";

    [SerializeField] int seconds = 5;

    [SerializeField] TMP_Text timeText;

    private void Awake()
    {
        BuildDefaultNotificationChannel();
    }

    private void BuildDefaultNotificationChannel()
    {
        string channel_id = "repeat";

        string title = "Repeat Channel";

        Importance importance = Importance.Default;

        string description = "Channel for repeating notifications";

        AndroidNotificationChannel defaultChannel = new AndroidNotificationChannel(channel_id, title, description, importance);

        AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);
    }

    public void SendNotif()
    {
        System.DateTime fireTime = System.DateTime.Now.AddSeconds(seconds);

        System.TimeSpan interval = new System.TimeSpan(0, 0, seconds);
        AndroidNotification notif = new AndroidNotification(notif_title, notif_message, fireTime);

        AndroidNotificationCenter.SendNotification(notif, "repeat");
    }

    public void AddTime()
    {
        seconds += 1;
        timeText.text = seconds.ToString();
    }

    public void MinusTime()
    {
        seconds -= 1;
        timeText.text = seconds.ToString();
    }

    
}
