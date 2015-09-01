using UnityEngine;
using System.Collections;

public class SolDead : UI_PopOnEventBase
{
	
	public GameObject[] sol;
	
	public override void OnDead ()
	{
		for(int i = 0; i < sol.Length; i++)
		{
			sol[i].SetActive(false);
		}
	}
}