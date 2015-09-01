using UnityEngine;
using System.Collections;

public class Terra : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(-0.002f, -0.001f, 0);
	}
}
