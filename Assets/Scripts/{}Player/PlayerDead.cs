using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDead : MonoBehaviour
{
    public PlayerInput playerInput;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            Debug.Log("I died, thank you forever");
            playerInput.enabled = false;
            Destroy(collision.gameObject);
        }
    }
}
