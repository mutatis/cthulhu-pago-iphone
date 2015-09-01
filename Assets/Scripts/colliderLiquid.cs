using UnityEngine;
using System.Collections;

public class colliderLiquid : MonoBehaviour {

	public int ia;
	public AudioClip[] die;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if(collider.gameObject.tag == "Liquid")
		{
			gameObject.SetActive(false);
		}
	}
	void OnCollisionrEnter2D (Collision2D collider)
	{
		if(collider.gameObject.tag == "Liquid")
		{
			gameObject.SetActive(false);
		}
	}
}