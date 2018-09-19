using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxlayersetplayer : MonoBehaviour {

	SpringJoint joint;
	void Start () {
		joint = GetComponent<SpringJoint>();
		joint.connectedBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
	}
}
