using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending_Script : MonoBehaviour {
    public Canvas canvas;
    public Text killer;
    public Text explorer;
    public Text socializer;
    public Text achiever;

    public GameObject killerPicture;
    public GameObject explorerPicture;
    public GameObject socializerPicture;
    public GameObject achieverPicture;

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        player.transform.parent.transform.position = new Vector3(0, 0, 0);
        player.transform.parent.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

        killer.text = killer.text + " " + PlayerAlignmentManager.Killer.ToString();
        explorer.text = explorer.text + " " + PlayerAlignmentManager.Explorer.ToString();
        socializer.text = socializer.text + " " + PlayerAlignmentManager.Socializer.ToString();
        achiever.text = achiever.text + " " + ((int)((PlayerAlignmentManager.Killer + PlayerAlignmentManager.Explorer + PlayerAlignmentManager.Socializer) / 3)).ToString();

        if (PlayerAlignmentManager.Killer == PlayerAlignmentManager.Explorer && PlayerAlignmentManager.Explorer == PlayerAlignmentManager.Socializer)
        {
            achieverPicture.SetActive(true);
        }
        if (PlayerAlignmentManager.Killer > PlayerAlignmentManager.Explorer && PlayerAlignmentManager.Killer > PlayerAlignmentManager.Socializer)
        {
            killerPicture.SetActive(true);
        }
        if (PlayerAlignmentManager.Explorer > PlayerAlignmentManager.Killer && PlayerAlignmentManager.Explorer > PlayerAlignmentManager.Socializer)
        {
            explorerPicture.SetActive(true);
        }
        if (PlayerAlignmentManager.Socializer > PlayerAlignmentManager.Killer && PlayerAlignmentManager.Socializer > PlayerAlignmentManager.Explorer)
        {
            socializerPicture.SetActive(true);
        }
    }
}
