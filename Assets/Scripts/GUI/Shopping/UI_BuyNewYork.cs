using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyNewYork : MonoBehaviour
{
	public int value;
	private string originalText;
	public GameObject select;
	public GameObject valor;
	public AudioClip[] botao;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasNewYork") == 1)
		{
			valor.SetActive(false);
			select.SetActive(true);
			gameObject.SetActive(false);
		}
	}
	
	public void EnableHasNewYork ()
	{
		if(GameManager.totalCoins >= value)
		{
			PlayerPrefs.SetInt("hasNewYork", 1);
			GameManager.Buy(value);
			GameManager.gameManager.hasNewYork = true;
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