using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text content;

    public static NotificationManager NotificationWindow(string titleMessage, string contentMessage)
    {
        GameObject notification = Instantiate(Resources.Load<GameObject>("Notification Window"));

        NotificationManager resultWindow = notification.GetComponent<NotificationManager>();

        resultWindow.title.text = titleMessage; // 제목
        resultWindow.content.text = contentMessage; // 내용

        return resultWindow;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
