using UnityEngine;
using System.Collections;

public class MovCamera : UI_PopOnEventBase 
{
	public GameObject[] estrela;

	public override void OnDead ()
	{
		for(int i = 0; i < estrela.Length; i++)
		{
			estrela[i].SetActive (true);
		}
	}
}
