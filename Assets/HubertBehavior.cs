using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// chatgpt influenced
public class HubertBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust this for your desired speed
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the player
        movement.x = Input.GetAxisRaw("Horizontal"); // Left and Right keys (or A/D keys)
        movement.y = Input.GetAxisRaw("Vertical");   // Up and Down keys (or W/S keys)
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.rotation = 0f;
    }
}