using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
// using UnityEditor.Callbacks;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int health;
    public int maxHealth;
    public float speed;
    private bool isFacingRight = false;
    public Transform[] spots;
    public Transform projectileSpawnPoint;
    public GameObject projectile;
    public float projectileSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector3 playerPos;
    public bool vulnerable;

    private Animator anim;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("PhaseOne");
        vulnerable = false;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if(other.gameObject.CompareTag("Wall")) {
        //     Flip();
        // }
    }

    IEnumerator PhaseOne() {

        yield return new WaitForSeconds(3f);

        while(true) {
            //FIRST ATTACK
            int randomSpot = Random.Range(0,2);
            while(transform.position.x!=spots[randomSpot].position.x) {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[randomSpot].position.x, transform.position.y),speed);

                yield return null;
            }

            yield return new WaitForSeconds(1f);

            int i = 0;
            while(i<3) {
                GameObject bullet = Instantiate(projectile,projectileSpawnPoint.position,Quaternion.identity);
                if(transform.position.x==spots[0].position.x) {
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right*projectileSpeed;
                    Vector3 localScale = bullet.transform.localScale;
                    localScale.x *= -1;
                    bullet.transform.localScale = localScale;
                } else if(transform.position.x==spots[1].position.x) {
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left*projectileSpeed;
                }
                i++;
                yield return new WaitForSeconds(.8f);
            }

            //SECOND ATTACK
            rb.isKinematic = true;
            while(transform.position.x!=spots[2].position.x) {
                transform.position = Vector2.MoveTowards(transform.position, spots[2].position,speed);

                yield return null;
            }

            playerPos = player.transform.position;

            while(transform.position.x!=playerPos.x) {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y),speed);

                yield return null;
            }

            yield return new WaitForSeconds(1f);
            rb.isKinematic = false;
            // yield return new WaitForSeconds(0.5f);
            vulnerable = true;
            anim.SetBool("vulnerable",vulnerable);
            yield return new WaitForSeconds(2f);
            if(vulnerable == true) {
                vulnerable = false;
                anim.SetBool("vulnerable",vulnerable);
            }

            while(transform.position.x!=playerPos.x) {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y),speed);

                yield return null;
            }

            // //THIRD ATTACK
            // Transform temp;
            // if(transform.position.x > player.transform.position.x) {
            //     temp = spots[0];
            // } else {
            //     temp = spots[1];
            // }

            // while(transform.position.x!=temp.position.x) {
            //     transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, transform.position.y),speed);

            //     yield return null;
            // }
        }
    }

    public void TakeDamage() {
        if(vulnerable) {
            health--;
            healthBar.SetHealth(health);
            if(health <= 0) {
                Destroy(this.gameObject);
            }
            vulnerable = false;
            anim.SetBool("vulnerable",vulnerable);
            speed *= 1.25f;
        }
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
