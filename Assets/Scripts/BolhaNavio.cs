using UnityEngine;
using System.Collections;

public class BolhaNavio : MonoBehaviour 
{

	public AudioSource au;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance(transform.position, PlayerStatus.playerStatus.transform.position) < 60)
		{
			if(!au.isPlaying)
			au.Play();
		}
		else
		{
			au.Stop();
		}
	}
}
