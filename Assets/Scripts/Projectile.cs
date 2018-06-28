using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	Vector3 startPosition;
	Quaternion startRotation;
	Rigidbody rb;
	bool projectileActive;

	public AudioSource projectileSound;
	public Transform parent;

	// Use this for initialization
	void Start () {

		// Initiate the projectileActive Boolean
		projectileActive = false;

		// Get the rigidbody for the projectile
		rb = gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -25)
		{
			resetProjectile();
		}
	}

	public void shootProjectile(GameObject projectile)
	{
		if (!projectileActive)
		{
			projectileActive = true;
			projectile.transform.SetParent(null);
			projectile.SetActive(true);
			Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
			rigidBody.isKinematic = false;
			//projectileSound.Play();
			rigidBody.AddTorque(0, 5f, 0, ForceMode.Impulse);
			rigidBody.AddForce(gameObject.transform.forward * 25f, ForceMode.Impulse);
		}
		
	}

	void resetProjectile()
	{
		projectileActive = false;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;
		transform.gameObject.SetActive(false);
		transform.position = parent.position;
		transform.rotation = parent.rotation;
		transform.SetParent(parent);
		
	}
}
