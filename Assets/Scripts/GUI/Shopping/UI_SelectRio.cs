using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SelectRio : MonoBehaviour 
{
	public GameObject selected;
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasRio") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasRio") == 0)
		{
			gameObject.SetActive(false);
		}
	}
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "Rio de Janeiro");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}
