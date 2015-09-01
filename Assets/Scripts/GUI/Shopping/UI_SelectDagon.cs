using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SelectDagon : MonoBehaviour 
{
	public Image image;
	public Sprite[] sprite;

	void Start()
	{
	}

	public void Dagon()
	{
		if(PlayerPrefs.GetString("Dagon") != "Dagon")
		{
			PlayerPrefs.SetString("Dagon", "Dagon");
			image.sprite = sprite[1];
		}
		else
		{
			PlayerPrefs.SetString("Dagon", "Cthulhu");
			image.sprite = sprite[0];
		}
	}
}
