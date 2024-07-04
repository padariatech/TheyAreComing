using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
	public float angleTilt = 35f;
	public float smoothness = 5f;
	Rigidbody rb;
	float horizontal;
	float vertical;
	[SerializeField] float speed;
	private void Start() {
		rb = GetComponent<Rigidbody>();
	
	}
	private void Update() {
		GetInput();
		SpeedLimiter();
	}
	private void GetInput()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
	}
	
	private void FixedUpdate() {
		Movement();
	}
	private void Movement()
	{
		Vector3 moveDirection = (Vector3.right * horizontal) + (Vector3.forward * vertical);
		rb.AddForce(moveDirection.normalized * speed * 10, ForceMode.Force);
	}
	private void SpeedLimiter()
	{
		Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
		if (flatVelocity.magnitude>speed)
		{
			Vector3 limitedVelocity = flatVelocity.normalized * speed;
			rb.velocity = new Vector3 (flatVelocity.x, 0, flatVelocity.z);
		}
		
	}
		private void Rotate(){
		float currentAngle = transform.localEulerAngles.z;
		float finalAngle = -Input.GetAxis("Horizontal") * angleTilt;
		float lerpAngle = Mathf.LerpAngle(currentAngle, finalAngle, smoothness * Time.deltaTime);
		transform.localEulerAngles = new Vector3(0f,0f,lerpAngle);
		}
}
