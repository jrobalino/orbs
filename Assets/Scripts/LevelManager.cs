using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public int numOrbs;
	int orbCount;
	public SteamVR_LoadLevel loadLevel;

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
			loadLevel.Trigger();
		}
	}

	public void orbHit()
	{
		orbCount++;
		checkSuccess();
	}
}
