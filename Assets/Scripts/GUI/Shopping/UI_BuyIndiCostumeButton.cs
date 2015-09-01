using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyIndiCostumeButton : MonoBehaviour
{
    public int value;
	public GameObject play;
	public GameObject valor;
	public AudioClip[] botao;

    void Start ()
    {
		if (PlayerPrefs.GetInt("hasIndi") == 1)
		{
			play.SetActive(true);
			gameObject.SetActive(false);
		}
	}

    public void EnableIndiCostume ()
    {
		if(GameManager.totalCoins >= value)
		{
			PlayerPrefs.SetInt("hasIndi", 1);
	        GameManager.Buy(value);
			GameManager.gameManager.hasIndi = true;
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
