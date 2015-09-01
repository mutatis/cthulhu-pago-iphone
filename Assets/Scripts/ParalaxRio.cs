using UnityEngine;
using System.Collections;

public class ParalaxRio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale != 0)
		{
			transform.Translate(-0.01f, 0, 0);
		}
	}
}
