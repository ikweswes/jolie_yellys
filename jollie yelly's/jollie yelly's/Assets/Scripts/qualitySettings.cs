﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qualitySettings : MonoBehaviour {

	public Slider slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		QualitySettings.SetQualityLevel((int)slider.value,false);
	}
}
