using UnityEngine;
using System.Collections;

public class UI_ManagerMO : MonoBehaviour 
{
	public int value;
	private string originalText;
	public GameObject select;
	public GameObject valor;
	public GameObject button;
	public GameObject cash;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasMoon") == 1)
		{
			valor.SetActive(false);
			select.SetActive(true);
			button.SetActive(false);
			cash.SetActive(false);
		}
	}

	void Update ()
	{
		if (PlayerPrefs.GetInt("hasMoon") == 0)
		{
			select.SetActive(false);
		}
		if (PlayerPrefs.GetInt("hasMoon") == 1)
		{
			cash.SetActive(false);
		}
	}
}
