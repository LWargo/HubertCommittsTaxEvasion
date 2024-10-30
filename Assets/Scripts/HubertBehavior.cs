using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

// chatgpt influenced
public class HubertBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust this for your desired speed
    public float moveSpeedHolder;
    private Rigidbody2D rb;
    private Vector2 movement;
    // public EnemyPatrol enemyPatrol;
    public Vector3 startpos;
    public TMP_Text icc_txt;
    int icc = 0;
    // public GameObject iceCream;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startpos = this.transform.position;
        icc_txt.SetText( "Ice Creams: " + icc);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            this.transform.position = startpos; //move player back to start
            icc = 0;
            icc_txt.text="Ice Creams: " + icc;
        }

        if(other.gameObject.CompareTag("IceCream")){
            Destroy(other.gameObject);
            icc++;
            icc_txt.text = "Ice Creams: " + icc;
        }

        if (other.gameObject.CompareTag("Powerup")) {
            Destroy(other.gameObject);
            moveSpeedHolder = moveSpeed;
            moveSpeed = 10f;
            StartCoroutine(DisablePowerup());
        }
    }

    IEnumerator DisablePowerup() {
        yield return new WaitForSeconds(5);
        moveSpeed = moveSpeedHolder;
    }
}