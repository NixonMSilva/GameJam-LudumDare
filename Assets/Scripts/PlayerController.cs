using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioManager audioManager;

    private Rigidbody2D rb;
    private CircleCollider2D col;

    private Vector2 movementVector;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private ContactFilter2D interactableFilter;

    private Animator anim;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        movementVector = Vector2.zero;
    }

    private void Update()
    {
        // Setting animator properties
        anim.SetFloat("horizontal", movementVector.x);
        anim.SetFloat("vertical", movementVector.y);
        anim.SetFloat("speed", movementVector.magnitude);

        // Analyzing directional input
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            InteractableCheck();
        }
    }

    private void FixedUpdate ()
    {
        PerformMovement(movementVector, speed);
    }

    private void PerformMovement (Vector2 direction, float speed)
    {
        Vector2 movement = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    public void ForceMove (Vector2 direction, float speed)
    {
        PerformMovement(direction, speed);
    }

    private void InteractableCheck ()
    {
        Interactable obj = null;
        List<Collider2D> lc = new List<Collider2D>();
        if (col.GetContacts(interactableFilter, lc) > 0)
        {
            foreach (Collider2D collisor in lc)
            {
                if (collisor != null && collisor.CompareTag("Interactable"))
                {
                    obj = collisor.GetComponent<Interactable>();
                    break;
                }
            }
            if (obj != null)
            {
                obj.Interact();
            }
        }
    }
}
