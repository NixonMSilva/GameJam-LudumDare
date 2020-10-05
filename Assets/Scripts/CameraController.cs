using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject currentCamera;

    [SerializeField]
    private GameObject player;

    private void Awake ()
    {
        currentCamera = this.gameObject;
    }

    private void Update ()
    {
        Vector3 newPosition = player.transform.position;
        newPosition.z = -10f;
        currentCamera.transform.position = newPosition;
    }
}
