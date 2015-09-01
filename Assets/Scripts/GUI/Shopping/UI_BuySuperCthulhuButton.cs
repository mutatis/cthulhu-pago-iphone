using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuySuperCthulhuButton : MonoBehaviour
{
    public int value;
    private string originalText;
	public GameObject play;
	public GameObject valor;
	public AudioClip[] botao;

    void Start ()
    {
		if (PlayerPrefs.GetInt("hasSCthulhu") == 1)
		{
			play.SetActive(true);
			gameObject.SetActive(false);
		}
	}
	
    public void EnableSuperCthulhuCostume ()
    {
		if(GameManager.totalCoins >= value)
		{
			PlayerPrefs.SetInt("hasSCthulhu", 1);
	        GameManager.Buy(value);
			GameManager.gameManager.hasSCthulhu = true;
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
