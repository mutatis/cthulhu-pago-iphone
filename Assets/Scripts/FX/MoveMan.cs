using UnityEngine;
using System.Collections;

public class MoveMan : MonoBehaviour 
{

	public float vel_x;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale != 0)
			transform.Translate(vel_x, 0, 0);
	}
}
