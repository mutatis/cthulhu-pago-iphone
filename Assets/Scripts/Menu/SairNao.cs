using UnityEngine;
using System.Collections;

public class SairNao : MonoBehaviour {

	public GameObject sair;

	public void Nao()
	{
		Time.timeScale = 1;
		sair.SetActive(false);
	}
}
