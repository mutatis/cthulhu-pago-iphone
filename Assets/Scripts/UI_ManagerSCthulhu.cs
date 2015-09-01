using UnityEngine;
using System.Collections;

public class UI_ManagerSCthulhu : MonoBehaviour {

	public int value;
	public GameObject valor;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasSCthulhu") == 1)
		{
			valor.SetActive(false);
		}
	}
}