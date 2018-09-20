using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sellectorScript : MonoBehaviour {

	public transAndPannel[] mainpannels;
	public KeyCode up = KeyCode.UpArrow;
	public KeyCode down = KeyCode.DownArrow;
	int index;
	// Update is called once per frame
	void Start(){
		index = 0;
		setposition();
	}

	void Update () {


		if(Input.GetKeyDown(up)){
			index -= 1;
			checkoutofrange();
			setposition();
		}
		else if(Input.GetKeyDown(down))
		{
			index += 1;
			checkoutofrange();
			setposition();
		}



	}

	void setposition(){
		
		foreach(transAndPannel tp in mainpannels )
		{
			tp.go.SetActive(false);
		}
		checkoutofrange();
		try{
		this.transform.position = mainpannels[index].tf.position;
		mainpannels[index].go.SetActive(true);
		}
		catch
		{
		}


	}

	void checkoutofrange()
	{
		if (index < 0)
			index = 0;

		if(index >= mainpannels.Length)
			index = mainpannels.Length -1;
		
	}
}


[System.Serializable]
public class transAndPannel
{
	public Transform tf;
	public GameObject go;
}
