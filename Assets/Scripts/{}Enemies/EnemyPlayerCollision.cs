using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerCollision : MonoBehaviour
{
    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponents<Collider2D>();
        var enemy = gameObject.GetComponents<Collider2D>();
        for(int i = 0; i < player.Length; i ++)
        {
            Physics2D.IgnoreCollision(enemy[i], player[i], true);
        }
    }
}
