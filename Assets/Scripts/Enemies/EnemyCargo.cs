using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class EnemyCargo : MonoBehaviour
{
	public float speed = 5f;

	void Start()
	{
		GetComponent<HealthSystem>().Died += Die;	
	}
	
	void Update()
	{
		Mover();
	}

	private void Mover()
	{
		Vector3 Horizontal = -transform.forward * Time.deltaTime * speed;
		transform.Translate(Horizontal);
	}
	
	void OnDestroy()
	{
		GetComponent<HealthSystem>().Died -= Die;
	}
	
	private void Die()
	{
		Destroy(gameObject);
	}

}
