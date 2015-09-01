using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SelectEgypt :MonoBehaviour 
{
	public GameObject selected;
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasEgypt") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasEgypt") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "Egypt");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}