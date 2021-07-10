using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D pc;
    private Rigidbody2D rb;
    private void Start()
    {
        anim = GetComponent<Animator>();
        pc = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            anim.SetBool("Dead", true);
            Destroy(collision.gameObject);
            pc.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
