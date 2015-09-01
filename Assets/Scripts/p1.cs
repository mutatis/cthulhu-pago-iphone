using UnityEngine;
using System.Collections;

public class p1 : MonoBehaviour 
{
	public Transform camera;
	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3(transform.position.x, -2.2027f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1)
		{
			transform.position = new Vector3(transform.position.x, camera.position.y-6, transform.position.z);
		}
	}
}
