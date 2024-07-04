using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private float spawnRate = 1f;
	[SerializeField] private float spawnRatetotal = 1f;
	[SerializeField] private GameObject[] enemyPrefabs;
	[SerializeField] private bool canSpawn = true;

	private void Start() {
	}
	private void Update()
	{
		spawnRate -= Time.deltaTime;
		if(spawnRate <= 0)
		{
			int rand = Random.Range(0, enemyPrefabs.Length);
			GameObject enemyToSpawn = enemyPrefabs[rand];

			Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
			spawnRate = spawnRatetotal;
		}
	}
	private IEnumerator Spawner() {
		WaitForSeconds wait = new WaitForSeconds(spawnRate);
		
		while (canSpawn) 
		{
			yield return wait;
			int rand = Random.Range(0, enemyPrefabs.Length);
			GameObject enemyToSpawn = enemyPrefabs[rand];

			Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
		}
	}
}
