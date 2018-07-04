using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public int numOrbs;
	int orbCount;
	public SteamVR_LoadLevel loadLevel;
	public AudioSource orbSound, levelCleared;

	// Use this for initialization
	void Start () {
		orbCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void checkSuccess()
	{
		if (orbCount >= numOrbs) 
		{
			levelCleared.Play();
			loadLevel.Trigger();
		}
	}

	public void orbHit()
	{
		orbSound.Play();
		orbCount++;
		checkSuccess();
	}
}
