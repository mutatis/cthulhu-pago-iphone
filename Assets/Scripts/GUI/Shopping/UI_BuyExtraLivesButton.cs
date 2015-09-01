using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyExtraLivesButton : MonoBehaviour
{
	public int value;
	public int howMany;
	public Text[] text;
	public GameObject[] button;
	public Text	 text1;
	public AudioClip[] botao;
	
	void Start ()
	{
		LoadData ();
		if(howMany > 5)
		{
			howMany = 5;
		}
		if (howMany == 5)
		{
			text1.text = "MAX";
			for(int i = 0; i < button.Length; i++)
			{
				button[i].SetActive(false);
			}
			for(int i = 0; i < 5; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
		}
		else if(howMany == 1)
		{
			text1.text = "2500";
			for(int i = 0; i < 1; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
			value = 2500;
		}
		else if(howMany == 2)
		{
			text1.text = "10000";
			for(int i = 0; i < 2; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
			value = 10000;
		}
		else if(howMany == 3)
		{
			text1.text = "20000";
			for(int i = 0; i < 3; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
			value = 20000;
		}
		else if(howMany == 4)
		{
			text1.text = "40000";
			for(int i = 0; i < 4; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
			value = 40000;
		}
		if(howMany < 5)
		text1.text = value.ToString();
	}
	
	void LoadData ()
	{
		howMany = PlayerPrefs.GetInt("extraLife");
	}
	
	void SaveData ()
	{
		PlayerPrefs.SetInt("extraLife", howMany);
	}
	
	public void EnableExtraLives ()
	{
		if(GameManager.totalCoins >= value)
		{
			GameManager.Buy(value);
			howMany ++;
			AudioSource.PlayClipAtPoint(botao[0], transform.position, 1f);
			if (howMany == 5)
			{
				text1.text = "MAX";
				for(int i = 0; i < button.Length; i++)
				{
					button[i].SetActive(false);
				}
				for(int i = 0; i < 5; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
			}
			else if(howMany == 1)
			{
				text1.text = "2500";
				for(int i = 0; i < 1; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
				value = 2500;
			}
			else if(howMany == 2)
			{
				text1.text = "10000";
				for(int i = 0; i < 2; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
				value = 10000;
			}
			else if(howMany == 3)
			{
				text1.text = "20000";
				for(int i = 0; i < 3; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
				value = 20000;
			}
			else if(howMany == 4)
			{
				text1.text = "40000";
				for(int i = 0; i < 4; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
				value = 40000;
			}
			if(howMany < 5)
				text1.text = value.ToString();
			GameManager.gameManager.extraLife = howMany;
			PlayerPrefs.SetInt("extraLife", howMany);
			SaveData ();
			if (howMany >= 5)
			{
				text1.text = "MAX";
				for(int i = 0; i < button.Length; i++)
				{
					button[i].SetActive(false);
				}
				howMany = 5;
			}
		}
		else
		{
			AudioSource.PlayClipAtPoint(botao[1], transform.position, 1f);
		}
	}
}
