using UnityEngine;
using System.Collections;

public class UI_PlayerCoins : MonoBehaviour
{

	void OnGUI ()
	{
		GetComponent<TextMesh>().text = GameManager.coins.ToString();
	}

	public void PlayCoins()
	{
		gameObject.SetActive(true);
	}
}