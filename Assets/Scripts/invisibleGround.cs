using UnityEngine;
using System.Collections;

public class invisibleGround : MonoBehaviour 
{
	public AudioClip[] die;
	void OnColisionEnter2D(Collision2D other)
	{
		if(PlayerStatus.playerStatus.lives <= 0 && other.gameObject.tag == "Player" && PlayerPrefs.GetString("Dagon") == "Dagon")
		{
			AudioSource.PlayClipAtPoint(die[0], transform.position, 1f); 
		}
	}
}
