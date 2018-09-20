using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continuePausemenu : MonoBehaviour {

	public PauseManager pm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			pm._continue = true;
		}
	}
}
