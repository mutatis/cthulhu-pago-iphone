using UnityEngine;
using System.Collections;

public class ColliderFim : MonoBehaviour 
{

	public Transform floor;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Bla")
		{
			floor.position = new Vector3(floor.position.x + 5, floor.position.y, floor.position.z);
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Bla")
		{
			floor.position = new Vector3(floor.position.x + 5, floor.position.y, floor.position.z);
		}
	}
}
