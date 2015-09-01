using UnityEngine;
using System.Collections;

public class UI_BuyFlappy : MonoBehaviour
{
	public int value;
	public GameObject play;
	public GameObject valor;
	public AudioClip[] botao;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasFlappy") == 1)
		{
			play.SetActive(true);
			gameObject.SetActive(false);
		}
	}
	
	public void EnableFlappyCostume ()
	{
		if(GameManager.totalCoins >= value)
		{
			PlayerPrefs.SetInt("hasFlappy", 1);
			GameManager.Buy(value);
			GameManager.gameManager.hasFlappy = true;
			AudioSource.PlayClipAtPoint(botao[0], transform.position, 1f);
			play.SetActive(true);
			valor.SetActive(false);
			gameObject.SetActive(false);
		}
		else
		{
			AudioSource.PlayClipAtPoint(botao[1], transform.position, 1f);
		}
	}
}
