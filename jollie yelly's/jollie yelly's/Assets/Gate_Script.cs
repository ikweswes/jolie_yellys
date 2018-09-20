using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Script : MonoBehaviour {
    private bool _active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_active)
        {
            transform.position += new Vector3(0, -1, 0);
        }
	}

    void Activate()
    {
        _active = true;
    }
}
