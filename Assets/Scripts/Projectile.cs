using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	Vector3 startPosition;
	Quaternion startRotation;
	Rigidbody rb;
	Transform parent;

	// Use this for initialization
	void Start () {

		// Get the start position and rotation of the projectile
		startPosition = transform.position;
		startRotation = transform.rotation;

		// Get the rigidbody for the projectile
		rb = gameObject.GetComponent<Rigidbody>();

		// Get the parent for the projectile
		parent = transform.parent;

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -25)
		{
			resetProjectile();
		}
	}

	void resetProjectile()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;
		transform.position = startPosition;
		transform.rotation = startRotation;
		transform.SetParent(parent);
		
	}
}
