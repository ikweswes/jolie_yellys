using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript ps = other.GetComponent<PlayerScript>();
            ps.collectibles++;
            ps.PlayCandy();
            this.gameObject.SetActive(false);
        }
    }
}
