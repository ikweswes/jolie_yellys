using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour {

	public AudioClip pressure;
	private AudioSource ac;
    public int weightRequirement;
    public GameObject player;
    public GameObject linkedObject;
    public LayerMask layer;
    private RaycastHit _hit;
    private PlayerScript _script;
	private bool iampressed = false;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        _script = player.GetComponent<PlayerScript>();
		ac = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, Vector3.up, out _hit, 1f,layer))
        {
            if (_hit.collider.CompareTag("Player"))
            {
                print("222");
                if (_script._weight >= weightRequirement)
                {
					if(!iampressed)
					{
                        print("111");
                        ac.PlayOneShot(pressure);
						iampressed = true;
                        linkedObject.SendMessage("Activate");
					}
                }
            }
        }
	}
}
