using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter:MonoBehaviour{

	TextMesh textmesh;
	public string textToSay;
	bool textStarted = false;
	public int maxchars = 20;
	public int maxLines = 3;

	List<string> allBoads = new List<string>();

	void Update()
	{
		if(textToSay != null && textStarted == false)
		{
			textmesh = this.GetComponentInChildren<TextMesh>();
			textmesh.text = "";
			StartCoroutine(TypeMachine());
			textStarted = true;
		}

		if(Input.GetKey(KeyCode.KeypadEnter))
		{
			Destroy(gameObject);
		}
	}





	public IEnumerator TypeMachine()
	{ 
		textStarted = true;
		allBoads = GenerateBoards();
		foreach (string board in allBoads)
		{
			foreach(char c in board)
			{
				textmesh.text+=c;
				yield return new WaitForSeconds(0.125f);
			}

			yield return new WaitForSeconds(1.5f);
	//		textmesh.text = string.Empty;
		}
	}



	public List<string> GenerateBoards()
	{
		List<string> returnvalue = new List<string>();
		string[] words = textToSay.Split(' ');
		int charcount = 0;
		int linecount = 0;
		string line = "";
		foreach(string word in words)
		{
			string wordclone = word;
			charcount += word.Length;
			if(charcount <= maxchars  && charcount!= 0)
			{
				//line = "";
				//Debug.Log("line: "+line);
			}
			else if (charcount > maxchars)
			{
				linecount++;
				charcount = 0;
			}
			if(linecount == maxLines)
			{
				returnvalue.Add(line);
				line = "";
				linecount = 0;
				charcount = 0;

			}
			if(charcount == 0)
			{
				Debug.Log("word"+word);
				line+=word+" ";
				Debug.Log("line"+line);
				charcount = word.ToCharArray().Length;
				Debug.Log(charcount);
			}
		}


		return returnvalue;
	}
}
