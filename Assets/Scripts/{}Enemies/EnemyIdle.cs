using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyIdle : MonoBehaviour
{
    /*public float speed;
    private float waitTime;
    public float startWaitTime;
    public bool patrollingEnemy;

    public Transform spotLook;

    private Rigidbody2D rb;*/

    public bool playerTrigger;
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public Transform[] patrolSpots;
    private int spotCounter = 0;

    #region components
    private Rigidbody2D rb;
    #endregion

    #region Pathfinding
    Path path;
    Seeker seeker;
    int currentWaypoint = 0;
    public float nextWaypointDistance = 3f;
    bool reachedEndOfPath = false;
    public Transform lookTarget;
    #endregion

    private void Start()
    {
        waitTime = startWaitTime;
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, startWaitTime);
    }

    private void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        PathMove();
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, patrolSpots[spotCounter].position, OnPathComplete);
            spotCounter++;
            if(spotCounter >= patrolSpots.Length)
            {
                spotCounter = 0;
            }
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    public void PathMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)path.vectorPath[currentWaypoint], speed * Time.deltaTime);

        Vector2 lookDir = lookTarget.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
            //StartCoroutine(SpotTimer());
            /*if(waitTime <= 0)
            {
                spotCounter++;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            if(spotCounter >= patrolSpots.Length)
            {
                spotCounter = 0;
            }*/
        }
    }

    IEnumerator SpotTimer()
    {
        Debug.Log("I'm here!");
        yield return new WaitForSeconds(2f);
        spotCounter++;
        if(spotCounter <= patrolSpots.Length)
        {
            spotCounter = 0;
        }
    }
    /*public void PatrolSpot()
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
    }*/
}
