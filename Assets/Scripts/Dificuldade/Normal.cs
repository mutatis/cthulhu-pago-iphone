using UnityEngine;
using System.Collections;

public class Normal : MonoBehaviour {

	public GameObject dificuldade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayGame()
	{
		PlayerPrefs.SetInt("dificuldade", 0);
		PlayerPrefs.SetInt("timeS", 1);
		Time.timeScale = 1F;
		dificuldade.SetActive(false);
	}
}
