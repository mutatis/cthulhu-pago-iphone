using UnityEngine;
using System.Collections;

public class IndiDead : UI_PopImage 
{
	public GameObject menu;
	public GameObject retry;
	public GameObject[] ativa;
	public GameObject[] desativa;

	public override void OnDead ()
	{
		for(int i = 0; i < ativa.Length; i++)
		{
			ativa[i].SetActive(true);
		}
		for(int i = 0; i < desativa.Length; i++)
		{
			desativa[i].SetActive(false);
		}
		menu.SetActive(true);
		retry.SetActive(true);
	}
}
