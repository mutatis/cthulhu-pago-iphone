﻿using UnityEngine;
using System.Collections;

public class Creditos : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void CreditosGo()
	{
		Application.LoadLevel("Creditos");
	}

	public void Play()
	{
		gameObject.SetActive(false);
	}
}
