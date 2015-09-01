using UnityEngine;
using System.Collections;

public class ManagerAudio2 : MonoBehaviour 
{
	public GameObject music;
	int ia;
	GameObject hand;
	public GameObject mao;
	public GameObject instmusic;
	bool mus;
	int us;

	// Use this for initialization
	void Start () 
	{
		mao = GameObject.Find("music(clone)");
		hand = GameObject.Find(hand.name);
		if(PlayerPrefs.GetInt("cuzinho") == 1)
		{
			Destroy(music.gameObject);
		}
		else
		{
			PlayerPrefs.SetInt("cuzinho", 1);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hand == null && mus == false && us == 0 && mao != null)
		{
			mus = true;
			us = 1;
		}
		if(mus)
		{
			Instantiate(instmusic);
			mus = false;
		}
	}

	public void CU()
	{
		PlayerPrefs.SetInt("cuzinho", 1);
	}
}
