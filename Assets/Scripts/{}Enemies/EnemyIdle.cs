using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public bool patrollingEnemy;

    private int spotCounter = 0;
    public Transform[] patrolSpots;
    public Transform spotLook;

    private Rigidbody2D rb;
    private void Start()
    {
        waitTime = startWaitTime;
        rb = GetComponent<Rigidbody2D>();
    }

    public void PatrolSpot()
    {
        if(patrollingEnemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolSpots[spotCounter].position, speed * Time.deltaTime);

            Vector2 lookDir = spotLook.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            if(Vector2.Distance(transform.position, patrolSpots[spotCounter].position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                    spotCounter++;
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            if(spotCounter == patrolSpots.Length)
            {
                spotCounter = 0;
            }
        }
    }
}
