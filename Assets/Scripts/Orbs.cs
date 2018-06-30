using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
	// This script controls how the orbs behave

	public AudioSource goodJob;
	public Transform center;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Rotate the orbs around a chosen center
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * 9f);
		transform.RotateAround(center.position, transform.up, Time.deltaTime * 9f);
	}

	private void OnCollisionEnter(Collision collision)
	{

		
		if (collision.collider.tag == "Shootable")
		{
			//goodJob.Play();
			collision.gameObject.SetActive(false);
			gameObject.SetActive(false);
		}
	}
}
