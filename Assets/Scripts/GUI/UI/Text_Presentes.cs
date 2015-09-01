using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Text_Presentes : UI_PopOnEventBase 
{
	bool morre;
	bool dead;
	int presente;
	Text textPres;
	int num;
	
	public override void OnDead ()
	{
		morre = true;
		dead = true;
		textPres.enabled = true;
		textPres.text = "" + GameManager.gameManager.kkk;
	}
	// Use this for initialization
	void Start () 
	{
		textPres = GetComponent<Text>();
		textPres.text = "" + GameManager.gameManager.kkk;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(num == 0)
		{
			GameManager.gameManager.kkk = 0;
			num = 1;
		}
	}
}