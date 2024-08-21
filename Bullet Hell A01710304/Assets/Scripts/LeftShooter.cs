using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftshooterSnake : MonoBehaviour
{
    public BulletsCounter bulletsCounter;
    public GameObject bulletPrefab;
    public int speed;
    public int numeroDePuntas = 5;  // Número de direcciones en las que disparará

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            ShootInMultipleDirections();
        }
    }

    void ShootInMultipleDirections()
    {
        for (int i = 0; i < numeroDePuntas; i++)
        {
            float degrees = (90f / numeroDePuntas);
            float angle = 225f + (degrees * i);
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

            Bullet DestroyBullet = bullet.GetComponent<Bullet>();
            DestroyBullet.bulletsCounter = bulletsCounter;

            bulletsCounter.IncrementBulletCount();
        }
    }
}
