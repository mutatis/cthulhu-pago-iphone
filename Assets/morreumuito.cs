using UnityEngine;
using System.Collections;

public class morreumuito : UI_PopOnEventBase 
{
	public GameObject shop;
	public GameObject shop1;
	public Animator shopA;
	int x;

	// Use this for initialization
	void Start () 
	{
		x = PlayerPrefs.GetInt("morreuA");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public override void OnDead ()
	{
		shop.SetActive(true);
		PlayerPrefs.SetInt("morreuA", x + 1);
		if(PlayerPrefs.GetInt("morreuA") == 3)
		{
			shopA.SetBool("shop", true);
			shop1.SetActive(true);
		}
	}
}
