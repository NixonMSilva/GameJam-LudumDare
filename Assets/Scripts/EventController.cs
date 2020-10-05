using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public void FireEvent (int index)
    {
        switch (index)
        {
            case 1:
                FireEvent01();
                break;
            case 2:
                FireEvent02();
                break;
            default:
                FireEventDefault();
                break;
        }
    }

    void FireEvent01 ()
    {

    }

    void FireEvent02 ()
    {

    }

    void FireEventDefault ()
    {
        Debug.Log("Default event fired, something is wrong.");
    }
}
