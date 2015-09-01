using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyDoubleStarButton : MonoBehaviour
{
	public int value;
	public AudioClip[] botao;
	public Image button;

	void Start ()
    {
		if (GameManager.gameManager.doubleCoin)
		{
			button.color = new Color(1, 1, 1, 0.25f);
		}
		else
		{
			button.color = new Color(1, 1, 1, 1);
		}
	}

	
    public void EnableDoubleCoin ()
    {
		if(GameManager.totalCoins >= value && GameManager.gameManager.doubleCoin == false)
		{
	        GameManager.Buy(value);
			GameManager.gameManager.doubleCoin = true;
			button.color = new Color(1, 1, 1, 0.25f);
			AudioSource.PlayClipAtPoint(botao[0], transform.position, 1f);
			PlayerPrefs.SetInt("doubleCoin", 1);
		}
		else
		{
			button.color = new Color(1, 1, 1, 0.25f);
			AudioSource.PlayClipAtPoint(botao[1], transform.position, 1f);
		}
	}
}