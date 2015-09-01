using UnityEngine;
using System.Collections;

public class mortepika : MonoBehaviour 
{
	bool ok;
	// Update is called once per frame
	void Update () 
	{
		if(PlayerStatus.playerStatus.lives <= 0 && ok == false)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
			ok = true;
		}
	}
}
