using UnityEngine;
using System.Collections;

public class UI_BuyChinaButton : MonoBehaviour {

	public int value;
	private string originalText;
	public GameObject select;
	public GameObject valor;
	public AudioClip[] botao;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasChina") == 1)
		{
			valor.SetActive(false);
			select.SetActive(true);
			gameObject.SetActive(false);
		}
	}
	
	public void EnableHasChina ()
	{
		if(GameManager.totalCoins >= value)
		{
			PlayerPrefs.SetInt("hasChina", 1);
			GameManager.Buy(value);
			GameManager.gameManager.hasChina = true;
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
