using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletsCounter bulletsCounter;

    void OnBecameInvisible() 
    {
        bulletsCounter.DecrementBulletCount();
        Destroy(gameObject);
    }
}
