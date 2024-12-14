using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    private Animator anim;
    private bool waiting = false;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if at patrol point, cycle to next patrol point
        if(transform.position == patrolPoints[targetPoint].position && !waiting) {
            IncreaseTargetInt();
        }
        // move from current position toward next patrol point every update
        if(!waiting) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        }
    }

    void IncreaseTargetInt() {

        targetPoint++;

        if(targetPoint >= patrolPoints.Length) {
            targetPoint = 0;
        }

        // if(Random.Range(0,1) < 0.2f) {
        //     // waitTime = Random.Range(0.5f,2);
        //     waitTime = 1;
        //     StartCoroutine(waitAMoment(waitTime));
        // }

        waitTime = 1;
        StartCoroutine(waitAMoment(waitTime));
    }

    IEnumerator waitAMoment(float t) {
        waiting = true;
        anim.SetBool("moving",false);
        // Debug.Log("IDLING");
        yield return new WaitForSeconds(t);
        waiting = false;
        // Debug.Log("NOW MOVING");
        anim.SetBool("moving",true);
    }
}
