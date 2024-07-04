using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikaze : MonoBehaviour
{
	private Transform target;
	Rigidbody rb;
	private Transform player;
	public float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
 target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update()
	{
	 transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
	
 }