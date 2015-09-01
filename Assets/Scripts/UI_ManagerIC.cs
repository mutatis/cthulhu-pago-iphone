using UnityEngine;
using System.Collections;

public class UI_ManagerIC : MonoBehaviour 
{
	public int value;
	private string originalText;
	public GameObject select;
	public GameObject valor;
	public GameObject button;
	public GameObject cash;
	
	void Start ()
	{
		if (PlayerPrefs.GetInt("hasIce") == 1)
		{
			valor.SetActive(false);
			select.SetActive(true);
			button.SetActive(false);
			cash.SetActive(false);
		}
	}
	void Update ()
	{
		if (PlayerPrefs.GetInt("hasIce") == 0)
		{
			select.SetActive(false);
		}
		if (PlayerPrefs.GetInt("hasIce") == 1)
		{
			cash.SetActive(false);
		}
	}
}
