using UnityEngine;

public class BulletShooterBlades : MonoBehaviour
{
    public BulletsCounter bulletsCounter;
    public GameObject bulletPrefab;
    public int nPuntas; // Número de pétalos
    public int bulletsPerPetal; // Número de balas por pétalo
    public float radius; // Radio del patrón
    public float bulletSpeed;
    public float curvature = 30f; // Controla la curvatura de las trayectorias de las balas

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ShootBladesPattern();
        }
    }

    void ShootBladesPattern()
    {
        for (int petal = 0; petal < nPuntas; petal++)
        {
            float petalAngleOffset = 360f / nPuntas * petal;

            for (int i = 0; i < bulletsPerPetal; i++)
            {
                // Distribuimos las balas dentro de cada pétalo con un ángulo ligeramente diferente para cada bala
                float angle = 360f / bulletsPerPetal * i + petalAngleOffset;

                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                float z = Mathf.Sin(angle * Mathf.Deg2Rad);
                
                // Añadimos un desplazamiento dentro del radio para evitar que las balas se superpongan
                float distanceFromCenter = radius * (i + 1) / bulletsPerPetal;

                // Curva la trayectoria de la bala ajustando el ángulo adicionalmente
                float curveAngle = curvature * (i / (float)bulletsPerPetal - 0.5f); // Varía de -curvature/2 a curvature/2
                float curvedX = Mathf.Cos((angle + curveAngle) * Mathf.Deg2Rad);
                float curvedZ = Mathf.Sin((angle + curveAngle) * Mathf.Deg2Rad);

                Vector3 bulletDir = new Vector3(curvedX, 0, curvedZ).normalized * distanceFromCenter;

                // Instanciamos la bala en la posición correspondiente
                GameObject bullet = Instantiate(bulletPrefab, transform.position + bulletDir, Quaternion.identity);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = bulletDir.normalized * bulletSpeed;

                Bullet DestroyBullet = bullet.GetComponent<Bullet>();
                DestroyBullet.bulletsCounter = bulletsCounter;

                bulletsCounter.IncrementBulletCount();
            }
        }
    }
}
