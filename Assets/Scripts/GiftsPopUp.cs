using UnityEngine;
using System.Collections;

public class GiftsPopUp : UI_PopOnEventBase 
{

	public GameObject[] gift;

	public override void OnDead ()
	{
		gift[GameManager.gameManager.gift].SetActive(true);
	}
}