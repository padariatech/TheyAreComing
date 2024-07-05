using UnityEngine;

public class Shooter : MonoBehaviour
{
	public Transform[] firePoints; 
	public float bulletSpeed = 20f;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		foreach (Transform firePoint in firePoints)
		{
			GameObject bullet = BulletPool.Instance.GetBullet(BulletPool.BulletType.PLAYER);
			bullet.transform.position = firePoint.position;
			bullet.transform.rotation = firePoint.rotation;
			Rigidbody rb = bullet.GetComponent<Rigidbody>();
			rb.velocity = firePoint.forward * bulletSpeed;
		}
	}
}
