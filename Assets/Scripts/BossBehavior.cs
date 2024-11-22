using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float timeBetweenAttacks;
    private bool attacking = false;
    public int health;
    public float speed;
    private bool isFacingRight = false;
    public Transform[] spots;
    public Transform projectileSpawnPoint;
    public GameObject projectile;
    public float projectileSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("PhaseOne");
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
            yield return new WaitForSeconds(1f);

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
        health--;
        if(health <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
