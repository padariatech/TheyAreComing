using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
	public enum BulletType{PLAYER, ENEMY};
	public static BulletPool Instance; 

	public GameObject bulletPrefab; 
	public int poolSize; 

	private Queue<GameObject> bulletPool;

	void Awake()
	{
		Instance = this;
		bulletPool = new Queue<GameObject>();

		for (int i = 0; i < poolSize; i++)
		{
			GameObject bullet = Instantiate(bulletPrefab);
			bullet.SetActive(false);
			bulletPool.Enqueue(bullet);
		}
	}

	public GameObject GetBullet(BulletType btype)
	{
		GameObject bullet;
		if (bulletPool.Count > 0)
		{
			bullet = bulletPool.Dequeue();
		}
		else
		{
			bullet = Instantiate(bulletPrefab);
		}
		if(btype == BulletType.PLAYER)
		{
			bullet.transform.GetChild(0).gameObject.SetActive(true);
			bullet.tag = "PlayerBullet";
		}else
		{
			bullet.transform.GetChild(1).gameObject.SetActive(true);
			bullet.tag = "EnemyBullet";
		}
		bullet.SetActive(true);
		return bullet;
	}

	public void ReturnBullet(GameObject bullet)
	{
		bullet.SetActive(false);
		for(int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
		bullet.tag = "Untagged";
		bulletPool.Enqueue(bullet);
	}
}
