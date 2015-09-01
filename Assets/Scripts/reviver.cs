using UnityEngine;
using System.Collections;

public class reviver : MonoBehaviour {
	
	public GameObject[] ok;
	
	void Start()
	{

	}

	void Update()
	{
		if(PlayerStatus.playerStatus.kk)
		{
			for(int i = 0; i < ok.Length-2; i++)
			{
				ok[i].SetActive(true);
			}
			ok[2].SetActive(false);
			ok[3].SetActive(false);
			PlayerStatus.playerStatus.kk = false;
		}
	}


}