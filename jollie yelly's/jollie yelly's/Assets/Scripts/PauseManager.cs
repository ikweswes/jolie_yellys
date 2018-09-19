using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    private object[] _scripts;
    private MonoBehaviour[] _actualScripts;
    private bool active = true;
	public GameObject pausemenu;
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
				pausemenu.SetActive(true);

            }
            else
            {
				Time.timeScale = 1;
				active = true;
				pausemenu.SetActive(false);

            }
        }
	}
}
