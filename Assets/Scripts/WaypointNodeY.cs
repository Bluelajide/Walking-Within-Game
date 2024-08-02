using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNodeY : MonoBehaviour
{
    public Transform[] patrolWay;
    public float speed;
    public int patrol;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    void Update()
    {
        if (patrol == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolWay[0].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolWay[0].position) < .2f)
            {
                transform.localScale = new Vector3(1, -1, 1);
                patrol = 1;
            }
        }

        if (patrol == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolWay[1].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolWay[1].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patrol = 0;
            }
        }
    }
}