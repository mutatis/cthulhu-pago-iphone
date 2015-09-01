using UnityEngine;
using System.Collections;

public class UI_BuyDagon : MonoBehaviour 
{
	public int value;
	private string originalText;
	public GameObject play;
	public GameObject valor;
	public GameObject dd;

	void Start ()
	{
		if (PlayerPrefs.GetInt("hasDagon") == 1)
		{
			valor.SetActive(false);
			play.SetActive(true);
			dd.SetActive(false);
		}
	}
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasDagon") == 1)
		{
			valor.SetActive(false);
			play.SetActive(true);
			dd.SetActive(false);
		}
	}
	
	public void EnableSuperCthulhuCostume ()
	{
		if(GameManager.totalCoins >= value)
		{
			PlayerPrefs.SetInt("hasDagon", 1);
			GameManager.Buy(value);
			GameManager.gameManager.hasDagon = true;
			play.SetActive(true);
			valor.SetActive(false);
		}
	}
}
