using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class EnemyKamikaze : MonoBehaviour
{
	private Transform target;
	Rigidbody rb;
	private Transform player;
	public float speed;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void Start()
	{
		GetComponent<HealthSystem>().Died += Die;
		player = GameObject.FindGameObjectWithTag("Player").transform;
 		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
	
	private void Die()
	{
		Destroy(gameObject);
	}
	
	void OnDestroy()
	{
		GetComponent<HealthSystem>().Died -= Die;
	}
 }