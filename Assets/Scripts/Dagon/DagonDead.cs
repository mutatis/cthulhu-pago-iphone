using UnityEngine;
using System.Collections;

public class DagonDead : MonoBehaviour
{
	public float posY;
	bool cu;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y <= posY && PlayerStatus.playerStatus.lives <= 0)
		{
			cu = true;
		}
		if(cu)
		{
			transform.position = new Vector3(transform.position.x, posY, transform.position.z);
		}
	}
}
