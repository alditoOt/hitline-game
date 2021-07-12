using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDead : MonoBehaviour
{
    private PlayerMovement movementScript;
    public bool dead = false;

    private void Start()
    {
        movementScript = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            dead = true;
            movementScript.moveSpeed = 0;
            movementScript.mousePosition = new Vector2(0f, 0f);
            Destroy(collision.gameObject);
        }
    }
}
