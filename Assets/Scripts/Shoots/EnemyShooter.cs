using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform[] firePoints;
    public float bulletSpeed = 20f;
    public float timeBetweenShots = 1f;

    private float shotTimer;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        shotTimer = 0f; 
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;

        if (shotTimer >= timeBetweenShots)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject bullet = BulletPool.Instance.GetBullet(BulletPool.BulletType.ENEMY);
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            Vector3 direction = (player.position - firePoint.position).normalized;

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = direction * bulletSpeed;
        }
    }
}
