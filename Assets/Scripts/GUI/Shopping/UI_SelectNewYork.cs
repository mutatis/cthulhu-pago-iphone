using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SelectNewYork : MonoBehaviour 
{
	public GameObject selected;
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasNewYork") == 1)
		{
			gameObject.SetActive(false);
		}
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasNewYork") == 1)
		{
			gameObject.SetActive(false);
		}
	}
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "NewYork");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}