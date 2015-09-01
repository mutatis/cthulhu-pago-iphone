using UnityEngine;
using System.Collections;

public class Desativando : UI_PopOnEventBase
{

	public GameObject[] desativar;

	public override void OnDead ()
	{
		for(int i = 0; i < desativar.Length; i++)
		{
			desativar[i].SetActive(false);
		}
	}
}
