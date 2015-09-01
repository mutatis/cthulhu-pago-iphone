using UnityEngine;
using System.Collections;

public class Sair : MonoBehaviour {

	public GameObject sair;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Home))
		{
			Time.timeScale = 0;
			sair.SetActive(true);
		}
	}
}
