using UnityEngine;
using System.Collections;

public class SlectAll : MonoBehaviour 
{

	public GameObject[] desativa;
	public GameObject[] ativa;

	public void Click()
	{
		for(int i = 0; i < desativa.Length; i++)
		{
			desativa[i].SetActive(false);
		}
		for(int i = 0; i < ativa.Length; i++)
		{
			ativa[i].SetActive(true);
		}
	}
}
