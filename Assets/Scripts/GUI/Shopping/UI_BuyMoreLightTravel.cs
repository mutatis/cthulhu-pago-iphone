using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuyMoreLightTravel : MonoBehaviour
{
    public int howMany;
    public int value;
	public Text text;
	public Button button;

    void Start ()
    {
        LoadData ();
		if(howMany > 5)
		{
			howMany = 5;
		}
		if (howMany == 5)
		{
			button.enabled = false;
			text.text = ". . . . .";
		}
		else if(howMany == 1)
			text.text = ".";
		else if(howMany == 2)
			text.text = ". .";
		else if(howMany == 3)
			text.text = ". . .";
		else if(howMany == 4)
			text.text = ". . . .";
	}


    void LoadData ()
    {
        howMany = PlayerPrefs.GetInt("LightTravel");
    }

    void SaveData ()
    {
        PlayerPrefs.SetInt("LightTravel", howMany);
    }

    public void BuyMoreLightTravel ()
    {
		if(GameManager.totalCoins >= value)
		{
	        GameManager.Buy(value);
	        howMany ++;
	        OftenSpawn.broughtProbalitys[2] = howMany * 100;
			if (howMany == 5)
			{
				button.enabled = false;
				text.text = ". . . . .";
			}
			else if(howMany == 1)
				text.text = ".";
			else if(howMany == 2)
				text.text = ". .";
			else if(howMany == 3)
				text.text = ". . .";
			else if(howMany == 4)
				text.text = ". . . .";
			SaveData ();
			if (howMany >= 5)
			{
				button.enabled = false;
				howMany = 5;
			}
		}
    }
}
