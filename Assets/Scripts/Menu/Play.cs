using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour 
{

	public GameObject cthulo;
	int time = 1;
	public GameObject dificuldade;

	public void Click()
	{
		PlayerPrefs.SetInt ("Galinhas", 0);
		cthulo.SetActive(false);
		gameObject.SetActive(false);
		dificuldade.SetActive(true);
	}

	public void PlayGame()
	{
		PlayerPrefs.SetInt("timeS", time);
		Time.timeScale = 1;
	}
}
