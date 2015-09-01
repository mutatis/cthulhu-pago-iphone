using UnityEngine;
using System.Collections;

public class DestroyCave : MonoBehaviour 
{
	public GameObject cave;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Destroy")
		{
			cave.gameObject.SetActive(false);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Destroy")
		{
			cave.gameObject.SetActive(false);
		}
	}
}
