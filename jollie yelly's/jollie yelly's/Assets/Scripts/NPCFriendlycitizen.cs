using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFriendlycitizen : NPCBase {


	public string[] dialogeText;
	public GameObject TexbubbelPrefab;
	[SerializeField]TexbubbleCreator texbubbel = new TexbubbleCreator();
	List<TypeWriter> writers;
	bool colliding = false;

	// Use this for initialization
	void Start () {
		friendly = true;
		health = PlayerPrefs.GetInt("enemyHealth",0);
		attackCooldown = 2;
		speed = 7;
		damageAbleToDeal = 1;
	}
	
	public override void DuringUpdate()
	{
		if(Input.GetKeyDown(KeyCode.KeypadEnter)&& colliding == true && writers == null){
			saytext();
		}
		else if(Input.GetKeyDown(KeyCode.KeypadEnter) && writers != null)
		{
			saytext();
		}
	}



	void saytext ()
	{
		
			
		if(writers == null)
		{
		TypeWriter textWriter =  Object.Instantiate(TexbubbelPrefab).GetComponent<TypeWriter>();
		textWriter.transform.position = new Vector3(-5f,5,0)+this.transform.position;
		textWriter.Say(dialogeText[0]);

		TypeWriter textWriter2 = Object.Instantiate(TexbubbelPrefab).GetComponent<TypeWriter>();
		textWriter2.transform.position = new Vector3(-5f,4,0)+this.transform.position;
		textWriter2.Say(dialogeText[1]);

		TypeWriter textWriter3 = Object.Instantiate(TexbubbelPrefab).GetComponent<TypeWriter>();
		textWriter3.transform.position = new Vector3(-5f,3,0)+this.transform.position;
		textWriter3.Say(dialogeText[2]);

		TypeWriter textWriter4 = Object.Instantiate(TexbubbelPrefab).GetComponent<TypeWriter>();
		textWriter4.transform.position = new Vector3(-5f,2,0)+this.transform.position;
		textWriter4.Say(dialogeText[3]);

		writers = new List<TypeWriter>();
			writers.Add(textWriter);
			writers.Add(textWriter2);
			writers.Add(textWriter3);
			writers.Add(textWriter4);

            PlayerAlignmentManager.AddPoints(PlayerAlignmentManager.PlayerType.SOCIALIZER, 1);
		}
		else
		{
			for(int i = 0;i<writers.Count;i++)
			{
				Object.Destroy(writers[i].gameObject);
			}
			writers = null;
		}
		

	}

	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			colliding = true;
		}
	}

	public void OnCollisionExit(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			colliding = false;
		}
	}
}
