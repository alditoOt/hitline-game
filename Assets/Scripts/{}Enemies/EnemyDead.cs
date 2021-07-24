using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private Animator anim;
    private Collider2D[] enemyCollider;
    private Rigidbody2D rb;
    private Shooting shootScript;

    public int hp = 1;

    public bool dead = false;
    private void Start()
    {
        enemyCollider = GetComponents<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            hp--;
            Destroy(collision.gameObject);
            if(hp <= 0)
            {
                if(!anim.GetBool("Dead"))
                {
                    GameManager.Instance.EnemyDead();
                    shootScript.ammo = shootScript.maxAmmo;
                    AudioManager.Instance.Play("enemyDead");
                    anim.SetBool("Dead", true);
                    var circleSprite = transform.GetChild(4);
                    circleSprite.gameObject.SetActive(false);
                }
                for(int i = 0; i < enemyCollider.Length; i ++)
                {
                    enemyCollider[i].enabled = false;
                }
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}
