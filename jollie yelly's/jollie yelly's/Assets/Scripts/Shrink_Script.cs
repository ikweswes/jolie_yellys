using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink_Script : MonoBehaviour {
    public GameObject player;
    private PlayerScript _script;
	// Use this for initialization
	void Start () {
        _script = player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            for (int i = _script._weight; i > 0; i--)
            {
                _script.ScaleTheSlime(false);
            }
        }
    }
}
