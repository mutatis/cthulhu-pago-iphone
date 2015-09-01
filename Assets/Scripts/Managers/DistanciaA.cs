using UnityEngine;
using System.Collections;

public class DistanciaA : MonoBehaviour {

	float percorreu;
	bool ok;

	void Awake()
	{
		NotificationCenter notificationCenter = NotificationCenter.DefaultCenter();
		notificationCenter.AddObserver(this, "QuitScene");
		notificationCenter.AddObserver(this, "OnDead");
	}

	// Use this for initialization
	void Start () 
	{
		percorreu = PlayerPrefs.GetFloat("percorreuS");
		percorreu += PlayerStatus.playerStatus.transform.position.x; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		//PlayerPrefs.SetFloat("percorreuS", percorreu);
	}

	void QuitScene ()
	{
		if(ok == false)
		{
			percorreu += PlayerStatus.playerStatus.transform.position.x;
			ok = true;
		}
		PlayerPrefs.SetFloat("percorreuS", percorreu);
	}
	void OnDead ()
	{
		percorreu = 0;
		PlayerPrefs.SetFloat("percorreuS", percorreu);
	}

	public void Zera()
	{
		percorreu = 0;
		PlayerPrefs.SetFloat("percorreuS", percorreu);
	}
}
