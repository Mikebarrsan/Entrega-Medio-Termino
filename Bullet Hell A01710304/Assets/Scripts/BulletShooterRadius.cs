using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootBullets : MonoBehaviour
{
    public BulletsCounter bulletsCounter;
    public GameObject bulletPrefab;
    public int speed;
    public int numeroDePuntas;  // Número de direcciones en las que disparará

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootInMultipleDirections();
        }
    }

    void ShootInMultipleDirections()
    {
        for (int i = 0; i < numeroDePuntas; i++)
        {
            float angle = i * (360f / numeroDePuntas);
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

            Bullet DestroyBullet = bullet.GetComponent<Bullet>();
            DestroyBullet.bulletsCounter = bulletsCounter;

            bulletsCounter.IncrementBulletCount();
        }
    }
}
