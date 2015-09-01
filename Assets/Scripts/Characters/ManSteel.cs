using UnityEngine;
using System.Collections;

public class ManSteel : MonoBehaviour 
{

	public Transform[] ok;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x < ok[0].position.x)
		{
			transform.position = new Vector2(ok[0].position.x, transform.position.y);
		}
		if(transform.position.x > ok[1].position.x)
		{
			transform.position = new Vector2(ok[1].position.x, transform.position.y);
		}
		if(transform.position.y <= -2.0005f)
		{
			transform.position = new Vector2(transform.position.x, -2.0005f);
		}
		if(transform.position.y >= 14.595f)
		{
			transform.position = new Vector2(transform.position.x, 14.595f);
		}
	}
}
