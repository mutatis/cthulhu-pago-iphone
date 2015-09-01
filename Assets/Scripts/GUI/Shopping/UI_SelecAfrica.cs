using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SelecAfrica : MonoBehaviour 
{
	public GameObject selected;
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasAfrica") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasAfrica") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "Africa");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}