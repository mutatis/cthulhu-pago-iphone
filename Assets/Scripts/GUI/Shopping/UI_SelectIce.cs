using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SelectIce : MonoBehaviour 
{
	public GameObject selected;
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasIce") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasIce") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "Ice");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}