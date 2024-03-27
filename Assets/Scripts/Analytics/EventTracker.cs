using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTracker : MonoBehaviour
{

    public string eventName;

    public void SendEvent()
    {
        AppMetrica.Instance.ReportEvent(eventName);
    }

}
