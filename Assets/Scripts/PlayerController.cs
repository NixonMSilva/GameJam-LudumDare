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

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
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
}
