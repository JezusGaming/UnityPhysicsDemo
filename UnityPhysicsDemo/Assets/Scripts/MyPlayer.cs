using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour {

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;
	Rigidbody RB;
	public GameObject mycamera;

	void Awake()
	{
		RB = gameObject.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float y = mycamera.transform.eulerAngles.y;
		float z = mycamera.transform.eulerAngles.z;
		Vector3 DirsedRot = new Vector3(0, y, z);
		transform.rotation = Quaternion.Euler(DirsedRot);

		if (grounded)
		{
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = RB.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			RB.AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (canJump && Input.GetButton("Jump"))
			{
				RB.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}

		// We apply gravity manually for more tuning control
		RB.AddForce(new Vector3(0, -gravity * RB.mass, 0));

		grounded = false;
	}

	void OnCollisionStay(Collision other)
	{
		if(other.gameObject.tag == "Wall")
		{
			canJump = false;
		}
		else
		{
			canJump = true;
			grounded = true;
		}
	}

	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}
