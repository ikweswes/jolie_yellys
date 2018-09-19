using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    private object[] _scripts;
    private MonoBehaviour[] _actualScripts;
    private bool active = true;
    // Use this for initialization
    void Start()
    {
        _scripts = Resources.LoadAll("Scripts");
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (active)
            {
				Time.timeScale = 0;
				active = false;

                //foreach (MonoBehaviour script in _scripts)
                //{
                //    script.enabled = false;
                //    active = false;
                //}
            }
            else
            {
				Time.timeScale = 1;
				active = true;

                //foreach (MonoBehaviour script in _scripts)
                //{
                //    script.enabled = true;
                //    active = true;
                //}
            }
        }
	}
}
