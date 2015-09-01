using UnityEngine;
using System.Collections;

public class ControleDagon : MonoBehaviour 
{
	public GameObject dagon;
	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetString("Dagon") == "Dagon" && Time.timeScale == 0)
		{
			dagon.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
