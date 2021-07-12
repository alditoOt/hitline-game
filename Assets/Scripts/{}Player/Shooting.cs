using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float bulletForce = 20f;
    public Transform playerPosition;
    private PlayerDead deadScript;

    public int ammo;
    public int maxAmmo = 6;
    public TextMeshProUGUI ammoUI;
    
    private void Start()
    {
        deadScript = GetComponent<PlayerDead>();
        ammo = maxAmmo;
    }

    private void FixedUpdate()
    {
        ammoUI.text = "Ammo: " + ammo.ToString();
    }
    void OnShoot()
    {
        if(!deadScript.dead)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(ammo > 0)
        {
            AudioManager.Instance.Play("Shoot");
            GameObject bullet = Instantiate(this.bullet, firePoint.position, firePoint.rotation);
            ammo--;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            playerPosition.position = transform.position;
            StopCoroutine("PlayerPositionTimer");
            playerPosition.gameObject.SetActive(true);
            StartCoroutine("PlayerPositionTimer");
        }
    }

    IEnumerator PlayerPositionTimer()
    {
        yield return new WaitForSeconds(0.5f);
        playerPosition.gameObject.SetActive(false);
    }
}
