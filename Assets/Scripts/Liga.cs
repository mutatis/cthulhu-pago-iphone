using UnityEngine;
using System.Collections;

public class Liga : UI_PopOnEventBase
{

	public GameObject[] liga;

	public override void OnDead ()
	{
		for(int i = 0; i < liga.Length; i++)
		{
			liga[i].SetActive(true);
		}
	}
}
