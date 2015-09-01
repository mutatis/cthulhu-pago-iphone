using UnityEngine;
using System.Collections;

public class ParalaxBackground : MonoBehaviour 
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
		{
			StartCoroutine("Flash");
			transform.Translate(vel_x, 0, 0);
			if(transform.position.x <= -14.617f)
			{
				transform.position = new Vector2(46.459f, transform.position.y);
			}
		}
	}
	IEnumerator Flash()
	{
		yield return new WaitForSeconds(2);
		//vel_x -= 0.0001f;
	}
}
