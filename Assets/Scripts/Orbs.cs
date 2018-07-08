using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
	// This script controls how the orbs behave

	public Transform center;
	public LevelManager levelManager;
	public float distance;
	public float degrees;
	public bool reverseDirection;
	float directionModifier = 1.0f;
	float speed = 9.0f;
	public bool modifySpeed;
	public float speedModifier = 1.0f;

	// Use this for initialization
	void Start()
	{
		// Place the orbs at a certain radius from the center
		transform.position = CreateCircle(center.position, distance, degrees);

		// Have the orbs (if they're quads) face the center of the stage
		transform.LookAt(center);

		// Set the orb's direction
		if (reverseDirection) 
		{
			directionModifier = -1.0f;	
		}

		// Set the orb's speed
		if (modifySpeed) 
		{
			speed = speed * speedModifier;
		}
	}

	// Update is called once per frame
	void Update()
	{
		// Rotate the orbs around a chosen center
		//transform.RotateAround(transform.position, transform.up, Time.deltaTime * 9f);
		transform.RotateAround(center.position, transform.up, Time.deltaTime * speed * directionModifier);
	}

	Vector3 CreateCircle(Vector3 center, float radius, float degrees)
	{ 
		// Creates a circle at the radius and angle specified
		Vector3 pos; 
		pos.x = center.x + radius * Mathf.Sin(degrees * Mathf.Deg2Rad); 
		pos.y = center.y; 
		pos.z = center.z + radius * Mathf.Cos(degrees * Mathf.Deg2Rad);
		return pos; 
	}

	private void OnCollisionEnter(Collision collision)
	{
		// When a projectile hits an orb, deactivate the orb and reset the projectile

		if (collision.collider.tag == "Projectile")
		{
			gameObject.SetActive(false);
			collision.gameObject.GetComponent<Projectile>().resetProjectile();
			levelManager.orbHit();
		}
	}
}
