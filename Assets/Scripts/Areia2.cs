using UnityEngine;
using System.Collections;

public class Areia2 : MonoBehaviour {

	public AudioSource au;
	public int type;
	bool ok;

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector2 (transform.position.x, 14.986f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(type == 0)
		{
			transform.position = new Vector2 (transform.position.x, 3.2f);
		}
		if (Vector3.Distance(transform.position, PlayerStatus.playerStatus.transform.position) < 210)
		{
			if(!au.isPlaying)
			{
				au.Play();
				ok = true;
			}
		}
		else if(ok)
		{
			au.volume -= 0.1f;
		}
	}
}
