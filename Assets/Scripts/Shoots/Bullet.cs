using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float secondsToDisappear;
	private void OnEnable() {
		Invoke(nameof(returnBullet), secondsToDisappear);	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent(out HealthSystem hSystem))
		{
			if((other.CompareTag("Player") && CompareTag("EnemyBullet")) || (other.CompareTag("Enemy") && CompareTag("PlayerBullet")))
			{
				hSystem.DecreaseHealth(1);
			}
			returnBullet();
		}
	}
	
	// void OnCollisionEnter(Collision collision)
	// {
	// 	returnBullet();
	// }

	void returnBullet()
	{
		BulletPool.Instance.ReturnBullet(gameObject);
	}
}
