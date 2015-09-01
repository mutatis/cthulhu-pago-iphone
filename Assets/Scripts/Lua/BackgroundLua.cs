﻿using UnityEngine;
using System.Collections;

public class BackgroundLua : MonoBehaviour 
{
	public Transform background;
	public Transform posX;
	public float soma = 59.0267f;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x <= posX.position.x - 30)
		{
			transform.position = new Vector3((background.position.x + soma), transform.position.y, transform.position.z);
		}
	}
}
