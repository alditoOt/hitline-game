using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject crosshairPrefab;
    public GameObject crosshair;
    public float bulletForce = 20f;
    public Transform playerPosition;
    private PlayerDead deadScript;

    public float distance;
    public int ammo;
    public int maxAmmo = 6;
    public TextMeshProUGUI ammoUI;
    
    private void Start()
    {
        deadScript = GetComponent<PlayerDead>();
        //crosshair = Instantiate(this.crosshairPrefab, firePoint.position, firePoint.rotation);
        ammo = maxAmmo;
    }

    private void FixedUpdate()
    {
        ammoUI.text = "Ammo: " + ammo.ToString();
        MoveCrosshair();
    }
    void OnShoot()
    {
        if(!deadScript.dead)
        {
            Shoot();
        }
    }

    void MoveCrosshair()
    {
        /*distance = Vector2.Distance(PlayerMovement.mousePosition, firePoint.position);
        if(distance >= 5)
        {
            distance = 5;
        }*/
        Debug.DrawLine(transform.position, PlayerMovement.mousePosition, Color.red);
        crosshair.GetComponent<Transform>().position = PlayerMovement.mousePosition;
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
