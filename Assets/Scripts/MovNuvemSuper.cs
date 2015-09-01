using UnityEngine;
using System.Collections;

public class MovNuvemSuper : MonoBehaviour {
	public float vel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale != 0)
		transform.Translate (vel, 0, 0);
	}
}
