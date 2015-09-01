using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyIce :MonoBehaviour
{
	public int value;
	private string originalText;
	public GameObject select;
	public GameObject valor;
	public AudioClip[] botao;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasIce") == 1)
		{
			valor.SetActive(false);
			select.SetActive(true);
			gameObject.SetActive(false);
		}
	}
	
	public void EnableHasIce ()
	{
		if(GameManager.totalCoins >= value)
		{
			PlayerPrefs.SetInt("hasIce", 1);
			GameManager.Buy(value);
			GameManager.gameManager.hasIce = true;
			AudioSource.PlayClipAtPoint(botao[0], transform.position, 1f);
			select.SetActive(true);
			valor.SetActive(false);
			gameObject.SetActive(false);
		}
		else
		{
			AudioSource.PlayClipAtPoint(botao[1], transform.position, 1f);
		}
	}
}