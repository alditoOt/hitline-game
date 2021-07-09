using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float bulletForce = 20f;
    public float startingFireRate = 3f;
    private float fireRate;

    private void Start()
    {
        fireRate = startingFireRate;
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        if(fireRate <= 0)
        {
            fireRate = startingFireRate;
            GameObject bullet = Instantiate(this.bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            fireRate -= Time.deltaTime;
        }
    }
}
