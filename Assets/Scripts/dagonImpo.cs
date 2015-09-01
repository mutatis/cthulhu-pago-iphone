using UnityEngine;
using System.Collections;

public class dagonImpo : MonoBehaviour 
{
	bool ok;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Jump2D.jump2D.grounded)
		{
			ok = true;
		}
		if(ok)
		{
			transform.Translate (2.5f, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			FollowTarget.espada.segui = true;
			PlayerStatus.playerStatus.StartCoroutine("Dying");
		}
	}
}
