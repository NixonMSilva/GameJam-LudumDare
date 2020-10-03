using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{

    /* The message box attached to this object, 
     * it's a vector it can be scaled for more
     * boxes appearing per object.    
    */

    public GameObject[] messageBoxes;

    private int noMessages, currentMessage;

    private void Awake ()
    {
        currentMessage = 0;
        noMessages = messageBoxes.Length;
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
        Debug.Log("Effect propagated!");
    }

    IEnumerator MessageDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        messageBoxes[currentMessage].SetActive(true);
    }
}
