using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var wall = collision.gameObject.layer;
        if (wall == 8)
        {
            Destroy(this.gameObject);
        }
    }
}
