using UnityEngine;
using System.Collections;

public class Caves : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3 (transform.position.x + 20, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
