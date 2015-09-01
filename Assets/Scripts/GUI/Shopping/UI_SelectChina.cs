using UnityEngine;
using System.Collections;

public class UI_SelectChina : MonoBehaviour {

	public GameObject selected;
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasChina") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasChina") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "China");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}
