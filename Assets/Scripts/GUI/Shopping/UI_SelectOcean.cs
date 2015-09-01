using UnityEngine;
using System.Collections;

public class UI_SelectOcean : MonoBehaviour 
{
	public GameObject selected;
	
	public void Select()
	{
		GameManager.gameManager.selectRio = true;
		PlayerPrefs.SetString("level", "Ocean");
		selected.SetActive(true);
		gameObject.SetActive(false);
	}
}