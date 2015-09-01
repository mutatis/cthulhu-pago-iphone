using UnityEngine;
using System.Collections;

public class sharedTwitter : MonoBehaviour {

	public void Click()
	{
		if(PlayerPrefs.GetInt("Twitter1") == 0)
		{
			GameManager.gameManager.AddCoin(2500);
			PlayerPrefs.SetInt("Twitter1", 1);
		}
	}
}
