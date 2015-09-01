using UnityEngine;
using System.Collections;

public class MorraAnti : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Anti")
		{
			Debug.Log("cu");
			Destroy(other.gameObject);
		}
	}
}
