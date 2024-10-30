using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if at patrol point, cycle to next patrol point
        if(transform.position == patrolPoints[targetPoint].position) {
            IncreaseTargetInt();
        }
        // move from current position toward next patrol point every update
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void IncreaseTargetInt() {
        targetPoint++;
        // transform.Rotate(0, 0, -90);
        // if the enemy has reached all patrol points, loop through all patrol points again
        if(targetPoint >= patrolPoints.Length) {
            targetPoint = 0;
        }
    }
}
