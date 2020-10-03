using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    InteractableController ic;

    // Check if the interactable has a text attached to it.
    [SerializeField]
    private bool hasText;

    // Check if the interactable has an effect attached to it.
    [SerializeField]
    private bool hasEffect;

    // Amount of delay to open the message. 0f = No delay.
    [SerializeField]
    private float delay = 0f;

    private void Awake ()
    {
        ic = GetComponent<InteractableController>();
    }

    public void ShowMessage ()
    {
        ic.ShowMessage();
    }

    public void ShowMessage (float delay)
    {
        ic.ShowMessage(delay);
    }

    public void Interact ()
    {
        if (hasEffect)
        {
            PropagateEffect();
        }

        if (hasText)
        {
            if (delay > 0f)
                ShowMessage(delay);
            else
                ShowMessage();
        }
    }

    public void PropagateEffect ()
    {
        ic.PropagateEffect();
    }
}
