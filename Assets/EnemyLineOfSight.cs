using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{
    public float distance;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LineOfSight()
    {
        RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, player.position);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if(hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("te vi jaja");
            }
            else
            {
                Debug.Log("No te veo we");
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + player.position * distance, Color.blue);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LineOfSight();
        }   
    }
}
