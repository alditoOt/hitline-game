using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{
    public float distance;
    private Transform player;
    private Animator anim;
    public LayerMask ignoreLayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponentInParent<Animator>();
    }

    void LineOfSight()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, (player.position - transform.position).normalized, distance, ~ignoreLayer);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if(hitInfo.collider.CompareTag("Player"))
            {
                anim.SetBool("InSight", true);
            }
            else
            {
                StopCoroutine(SightTimer());
                StartCoroutine(SightTimer());
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StopCoroutine(SightTimer());
            StartCoroutine(SightTimer());
        }
    }

    IEnumerator SightTimer()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("InSight", false);
    }
}
