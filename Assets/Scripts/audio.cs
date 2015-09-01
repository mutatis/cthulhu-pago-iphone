using UnityEngine;
using System.Collections;

public class audio : MonoBehaviour {
	public AudioClip otherClip;
	// Use this for initialization
	void Start () 
	{
		audio.clip = otherClip;
		audio.Play();
		audio.volume = 1F;
		audio.priority = 255;
	}
	
	// Update is called once per frame
	void Update () {
		audio.volume = 1F;
		audio.priority = 255;
	}
}
