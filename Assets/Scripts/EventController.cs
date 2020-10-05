using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController current;

    private void Awake ()
    {
        current = this;
    }

    public void FireEvent (int index)
    {
        switch (index)
        {
            case 1:
                onLightSwitch01();
                break;
            case 2:
                sendToLevel02();
                break;
            default:
                FireEventDefault();
                break;
        }
    }

    public event Action onLightSwitch01;
    public event Action sendToLevel02;

    public void LightSwitch01 ()
    {
        if (onLightSwitch01 != null)
        {
            onLightSwitch01();
        }
    }

    public void SendToLevel02 ()
    {
        if (sendToLevel02 != null)
        {
            sendToLevel02();
        }
    }

    void FireEventDefault ()
    {
        Debug.Log("Default event fired, something is wrong.");
    }
}
