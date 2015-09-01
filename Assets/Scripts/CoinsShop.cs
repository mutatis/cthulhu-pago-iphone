using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinsShop : MonoBehaviour 
{
	public static float coins;
	Text text;

	void Awake()
	{
		text = GetComponent<Text>();
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		coins = GameManager.totalCoins;
		text.text = " \t" + coins;
	}
}
