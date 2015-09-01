using UnityEngine;
using System.Collections;

public class WaterFollow : MonoBehaviour {
	public Transform sun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(sun.position.x+0.05f, sun.position.y-18, transform.position.z);
	}
}
