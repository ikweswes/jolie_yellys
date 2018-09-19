using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class volumeslider : MonoBehaviour {

	public Slider slider;
	public AudioMixer mixer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mixer.SetFloat("Volume",slider.value);
	}
}
