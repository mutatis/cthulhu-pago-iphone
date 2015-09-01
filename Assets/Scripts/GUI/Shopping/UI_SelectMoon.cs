using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SelectMoon : MonoBehaviour 
{
	public GameObject selected;

	void Start ()
	{
		if (PlayerPrefs.GetInt("hasMoon") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasMoon") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "Lua");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}