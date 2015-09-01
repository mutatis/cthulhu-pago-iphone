using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyJump : MonoBehaviour
{
	public int value;
	public int howMany;
	public Text[] text;
	public GameObject[] button;
	public Text text1;
	public AudioClip[] botao;
	
	void Start ()
	{
		LoadData ();
		if(howMany > 7)
		{
			howMany = 7;
		}
		if (howMany == 7)
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
		else if(howMany == 3)
		{
			for(int i = 0; i < 1; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
			value = 2500;
		}
		else if(howMany == 4)
		{
			text1.text = "10000";
			for(int i = 0; i < 2; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
			value = 10000;
		}
		else if(howMany == 5)
		{
			text1.text = "20000";
			for(int i = 0; i < 3; i ++)
			{
				text[i].color = new Color(1f,1f,1f,1f);;
			}
			value = 20000;
		}
		else if(howMany == 6)
		{
			text1.text = "20000";
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
		howMany = PlayerPrefs.GetInt("JumpMore");
	}
	
	void SaveData ()
	{
		PlayerPrefs.SetInt("JumpMore", howMany);
	}
	
	public void EnableExtraLives ()
	{
		if(GameManager.totalCoins >= value)
		{
			GameManager.Buy(value);
			howMany ++;
			AudioSource.PlayClipAtPoint(botao[0], transform.position, 1f);
			if (howMany == 7)
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
			else if(howMany == 3)
			{
				text1.text = "2500";
				for(int i = 0; i < 1; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
				value = 2500;
			}
			else if(howMany == 4)
			{
				text1.text = "10000";
				for(int i = 0; i < 2; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
				value = 10000;
			}
			else if(howMany == 5)
			{
				text1.text = "20000";
				for(int i = 0; i < 3; i ++)
				{
					text[i].color = new Color(1f,1f,1f,1f);;
				}
				value = 20000;
			}
			else if(howMany == 6)
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
			PlayerPrefs.SetInt("JumpMore", howMany);
			SaveData ();
			if (howMany >= 7)
			{
				text1.text = "MAX";
				for(int i = 0; i < button.Length; i++)
				{
					button[i].SetActive(false);
				}
				howMany = 7;
			}
		}
		else
		{
			AudioSource.PlayClipAtPoint(botao[1], transform.position, 1f);
		}
	}
}
