using UnityEngine;
using System.Collections;

public class UI_ManagerFlappy : MonoBehaviour {

	public int value;
	public GameObject valor;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasFlappy") == 1)
		{
			valor.SetActive(false);
		}
	}
}
