using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private Shooting shootScript;

    private void Start()
    {
        shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            shootScript.ammo = shootScript.maxAmmo;
            Destroy(this.gameObject);
            AudioManager.Instance.Play("enemyDead");
        }
    }
}
