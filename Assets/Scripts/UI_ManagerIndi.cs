using UnityEngine;
using System.Collections;

public class UI_ManagerIndi : MonoBehaviour {

	public int value;
	public GameObject valor;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasIndi") == 1)
		{
			valor.SetActive(false);
		}
	}
}
