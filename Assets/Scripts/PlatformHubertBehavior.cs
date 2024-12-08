using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformHubertBehavior : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isFacingRight = true;

    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    public float knockbackForce;
    private bool isKnockingBack;

    public BossBehavior boss;
    private GameObject levelManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        boss = GameObject.Find("PlatformBoss").GetComponent<BossBehavior>();
        levelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight && horizontal < 0f) Flip();
        if(!isFacingRight && horizontal > 0f) Flip();
        anim.SetBool("onGround",IsGrounded());
        if(horizontal != 0) {
            anim.SetBool("moving",true);
        } else {
            anim.SetBool("moving",false);
        }
    }

    void FixedUpdate() {
        if(!isKnockingBack) {
            rb.velocity = new UnityEngine.Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Boss") && other.collider.bounciness < 1){
            if(!isKnockingBack) {
                health--;
                healthBar.SetHealth(health);
                if(health<=0) {
                    levelManager.GetComponent<LevelManager>().gameOver();
                }
            }
            StartCoroutine(Knockback(knockbackForce));
        } else if(other.gameObject.CompareTag("Boss")) {
            boss.TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Projectile")) {
            if(!isKnockingBack) {
                health--;
                healthBar.SetHealth(health);
                if(health<=0) {
                    levelManager.GetComponent<LevelManager>().gameOver();
                }
            }
            StartCoroutine(Knockback(knockbackForce));
        }
    }

    void OnJump(InputValue value) {
        if (IsGrounded()) rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        if (!value.isPressed && !IsGrounded()) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
    }

    void OnMove(InputValue value) {
        horizontal = value.Get<float>();
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position,.1f,groundLayer);
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private IEnumerator Knockback(float kb) {
        isKnockingBack = true;
        if(isFacingRight) {
            rb.AddForce(Vector2.left*kb);
        } else {
            rb.AddForce(Vector2.right*kb);
        }
        rb.AddForce(Vector2.up*kb);
        yield return new WaitForSeconds(.5f);
        isKnockingBack = false;
    }
}
