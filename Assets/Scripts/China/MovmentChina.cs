using UnityEngine;
using System.Collections;

public class MovmentChina : MonoBehaviour 
{

	public float velX;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale != 0 && PlayerStatus.playerStatus.lives > 0)
			transform.Translate(velX, 0, 0);
	}
}
