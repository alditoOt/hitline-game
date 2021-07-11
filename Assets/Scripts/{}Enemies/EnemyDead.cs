using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private Animator anim;
    private Collider2D[] enemyCollider;
    private Rigidbody2D rb;

    public bool dead = false;
    private void Start()
    {
        enemyCollider = GetComponents<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            anim.SetBool("Dead", true);
            Destroy(collision.gameObject);
            GameManager.Instance.EnemyDead();
            for(int i = 0; i < enemyCollider.Length; i ++)
            {
                enemyCollider[i].enabled = false;
            }
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
