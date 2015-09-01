using UnityEngine;
using System.Collections;

public class Impossibru : MonoBehaviour {

	public static Impossibru impo;
	public GameObject dificuldade;
	public bool ok;
	public GameObject impossibru;

	void Awake()
	{
		impo = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayGame()
	{
		ok = true;
		PlayerPrefs.SetInt ("Kill", Random.Range(0, 5));
		PlayerStatus.playerStatus.lives = 1;
		PlayerPrefs.SetInt("dificuldade", 2);
		PlayerPrefs.SetInt("timeS", 1);
		Time.timeScale = 1F;
		if(impossibru != null)
		{
			impossibru.SetActive(true);
		}
		dificuldade.SetActive(false);
	}
}
