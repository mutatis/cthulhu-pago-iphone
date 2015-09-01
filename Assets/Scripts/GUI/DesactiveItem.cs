using UnityEngine;
using System.Collections;

public class DesactiveItem : MonoBehaviour
{
	public GameObject[] desactive;

	public void Desativar()
	{
		Destroy (desactive [1].gameObject);
		for(int i = 0; i < desactive.Length; i++)
		{
			desactive[i].SetActive(false);
		}
	}
}
