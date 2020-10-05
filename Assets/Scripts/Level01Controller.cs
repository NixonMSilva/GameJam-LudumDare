using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level01Controller : MonoBehaviour
{
    private bool isLightOn = false;

    public GameObject livingRoomBlock, livingRoomTeleport, livingRoomLight;

    private void Start ()
    {
        EventController.current.onLightSwitch01 += LightSwitch;
        EventController.current.sendToLevel02 += SendToLevel02;
    }

    private void LightSwitch ()
    {
        livingRoomBlock.SetActive(false);
        livingRoomLight.SetActive(true);
        livingRoomTeleport.SetActive(true);
    }

    private void SendToLevel02 ()
    {
        SceneManager.LoadScene("Dream02");
    }
}
