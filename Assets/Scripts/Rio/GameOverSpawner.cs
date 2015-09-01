using UnityEngine;
using System.Collections;

public class GameOverSpawner : UI_PopOnEventBase
{

	public GameObject[] spawner;

	public override void OnDead ()
	{
		for(int i = 0; i < spawner.Length; i++)
		{
			spawner[i].SetActive(false);
		}
	}
}
