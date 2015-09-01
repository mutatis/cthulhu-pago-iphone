using UnityEngine;
using System.Collections;

public class DeadSupercthulhu : MonoBehaviour
{

	public Transform super;

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector2(super.position.x + 2, super.position.y);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerStatus.playerStatus.lives > 0)
		{
			transform.position = new Vector2(super.position.x + 2, super.position.y);
		}
		else
		{
			transform.Translate(-0.3f, -0.4f, 0);
		}
	}	
}
