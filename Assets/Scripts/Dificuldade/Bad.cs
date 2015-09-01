using UnityEngine;
using System.Collections;

public class Bad : MonoBehaviour 
{
	public GameObject texto3;
	int x;
	public GameObject easy;
	public GameObject easy2;
	public GameObject pause;

	void Start()
	{
		x = PlayerPrefs.GetInt("Facil");
	}

	public void BadPlay()
	{
		x++;
		PlayerPrefs.SetInt("Facil", x);
		if(x >= 50)
		{
			easy.SetActive(true);
			easy2.SetActive(true);
		}
		else
		{
			PlayerPrefs.SetInt("dificuldade", 1);
			PlayerPrefs.SetInt("timeS", 1);
			Time.timeScale = 1f;
			texto3.SetActive(false);
			pause.SetActive(true);
		}
	}
}
