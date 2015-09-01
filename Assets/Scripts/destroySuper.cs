using UnityEngine;
using System.Collections;

public class destroySuper : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Coin" || coll.gameObject.tag == "Bla")
		{
			Destroy(coll.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Coin")
		{
			Destroy (coll.gameObject);
		}
	}
}
