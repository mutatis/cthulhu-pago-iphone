using UnityEngine;
using System.Collections;

public class managerAudio : MonoBehaviour 
{

	bool vol;

	void Update()
	{
		if((vol && audio.volume <= 1) || Time.timeScale == 1)
		{
			audio.volume += 0.01f;
		}
	}

	public void Play()
	{
		vol = true;
	}
	public void Muda()
	{
		PlayerPrefs.SetInt("cuzinho", 0);
		Destroy(gameObject);
	}
}
