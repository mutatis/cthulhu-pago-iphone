using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour 
{
	public float scale;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.localScale.x < scale)
		{
			transform.localScale *= 1.13f;
		}
	}
}
