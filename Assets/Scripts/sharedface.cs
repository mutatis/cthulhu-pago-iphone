using UnityEngine;
using System.Collections;

public class sharedface : MonoBehaviour {

	public void Click()
	{
		if(PlayerPrefs.GetInt("Face1") == 0)
		{
			GameManager.gameManager.AddCoin(2500);
			PlayerPrefs.SetInt("Face1", 1);
		}
	}
}
