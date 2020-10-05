using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    InteractableController ic;

    // Check if the triggerable has a text attached to it.
    [SerializeField]
    private bool hasText;

    // Check if the triggerable has an effect attached to it.
    [SerializeField]
    private bool hasEffect;

    // Amount of delay to open the message. 0f = No delay.
    [SerializeField]
    private float delay = 0f;

    private void Awake ()
    {
        ic = GetComponent<InteractableController>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (hasText)
            {
                if (delay > 0f)
                {
                    ic.ShowMessage();
                }
                else
                {
                    ic.ShowMessage(delay);
                }
            }
        }
    }
}
