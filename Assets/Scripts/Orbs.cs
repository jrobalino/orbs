using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
	// This script controls how the orbs behave

	public Transform center;
	public LevelManager levelManager;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Rotate the orbs around a chosen center
		//transform.RotateAround(transform.position, transform.up, Time.deltaTime * 9f);
		transform.RotateAround(center.position, transform.up, Time.deltaTime * 9f);
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
