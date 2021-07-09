using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D pc;
    private void Start()
    {
        anim = GetComponent<Animator>();
        pc = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            anim.SetBool("Dead", true);
            Destroy(collision.gameObject);
            pc.enabled = false;
        }
    }
}
