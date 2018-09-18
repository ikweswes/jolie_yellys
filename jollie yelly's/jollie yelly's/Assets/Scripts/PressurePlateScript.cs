using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour {

    public int weightRequirement = 5;
    public GameObject player;
    private RaycastHit _hit;
    private PlayerScript _script;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        _script = player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, Vector3.up, out _hit, 0.5f))
        {
            if (_hit.collider.CompareTag("Player"))
            {
                if (_script._weight >= weightRequirement)
                {
                    //DO WHATEVER

                    //for (int i = weightRequirement - 1; i > 0; i--)
                    //{
                    //    _script.ScaleTheSlime(false);
                    //}
                }
            }
        }
	}
}
