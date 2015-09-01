using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Text_Coins : UI_PopOnEventBase 
{
	bool morre;
	bool dead = true;
	float coins;
	float oi;
	float moedas;
	Text textCoins;
	public UI_Dead aah;

	public override void OnDead ()
	{
		dead = true;
		textCoins.enabled = true;
		morre = true;
		coins = GameManager.gameManager.sCoins;
		//coins *= -1;
		if(coins != 0)
		{
			oi = coins;
		}
	}
	// Use this for initialization
	void Start () 
	{
		textCoins = GetComponent<Text>();
		coins = GameManager.gameManager.sCoins;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(coins != 0)
		{
			oi = coins;
		}
		//if(aah.aah >= 500 && aah.compre >= 5)
		//{
			if(Input.GetMouseButtonDown(0) && morre)
			{
				dead = false;
				moedas = oi;
			}
			if(dead)
			{
				if(moedas < oi)
				{
					moedas += 1;
				}
				else
				{
					moedas = oi;
				}
			}
		//}
		textCoins.text = "" + moedas;
	}
}

