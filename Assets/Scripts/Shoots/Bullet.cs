using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float secondsToDisappear;
	private void OnEnable() {
		Invoke(nameof(returnBullet), secondsToDisappear);	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		returnBullet();
	}

	void returnBullet()
	{
		BulletPool.Instance.ReturnBullet(gameObject);
	}
}
