using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_End_Script : MonoBehaviour {
    private string _levelName;
    private string _targetLevel;
    private string _lastChar;
    private int _levelNumber;

	// Use this for initialization
	void Start () {
        _levelName = SceneManager.GetActiveScene().name;
        _lastChar = _levelName.Substring(_levelName.Length - 1);
        _levelNumber = int.Parse(_lastChar) + 1;
        _targetLevel = _levelName.Substring(0, _levelName.Length - 1) + _levelNumber.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(_targetLevel);
    }
}
