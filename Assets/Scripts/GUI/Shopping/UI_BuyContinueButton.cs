using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyContinueButton : MonoBehaviour
{
    public int value = 2000;
	private string originalText;
	public AudioClip[] botao;
	public Image button;

    void Start ()
    {
	    if (GameManager.gameManager.hasContinue)
		{
			PlayerPrefs.SetInt("hasContinue", 1);
			button.color = new Color(1, 1, 1, 0.25f);
		}
		else
		{
			button.color = new Color(1, 1, 1, 1);
		}
	}

	void Update()
	{
		Debug.Log(GameManager.totalCoins);
	}
	
    public void EnableHasContinue ()
    {
		if(GameManager.totalCoins >= value && GameManager.gameManager.hasContinue == false)
		{
			PlayerPrefs.SetInt("hasContinue", 1);
	        GameManager.Buy(value);
			button.color = new Color(1, 1, 1, 0.25f);
			AudioSource.PlayClipAtPoint(botao[0], transform.position, 1f);
	        GameManager.gameManager.hasContinue = true;
		}
		else
		{
			button.color = new Color(1, 1, 1, 0.25f);
			AudioSource.PlayClipAtPoint(botao[1], transform.position, 1f);
		}
    }
}
