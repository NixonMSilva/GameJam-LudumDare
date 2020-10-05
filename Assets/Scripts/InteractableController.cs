using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{

    /* The message box attached to this object, 
     * it's an array - it can be scaled for more
     * boxes appearing per object.    
    */

    public GameObject[] messageBoxes;

    public int eventIndex = 0;

    private int noMessages, currentMessage;

    private GameObject eventController;

    private void Awake ()
    {
        currentMessage = 0;
        noMessages = messageBoxes.Length;
        eventController = GameObject.FindGameObjectWithTag("EventController");
    }

    public void ShowMessage ()
    {
        messageBoxes[currentMessage].SetActive(true);
    }

    public void ShowMessage (float delay)
    {
        StartCoroutine(MessageDelay(delay));
    }

    public void PropagateEffect ()
    {
        eventController.GetComponent<EventController>().FireEvent(eventIndex);
    }

    IEnumerator MessageDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        messageBoxes[currentMessage].SetActive(true);
    }
}
