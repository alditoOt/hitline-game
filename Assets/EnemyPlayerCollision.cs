using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerCollision : MonoBehaviour
{
    private Collider2D player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player, true);
    }
}
