using UnityEngine;
using System.Collections;

public class runsound : MonoBehaviour {

	//AudioSource audio;

	// Use this for initialization
	void Start () 
	{
		//audio.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Jump2D.jump2D.grounded && rigidbody2D.velocity.x != 0 && !audio.isPlaying && Time.timeScale != 0)
		{
			audio.Play();
		}
		if(!Jump2D.jump2D.grounded)
		{
			audio.Stop();
		}
	}
}
