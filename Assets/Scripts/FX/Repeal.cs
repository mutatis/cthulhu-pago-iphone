using UnityEngine;
using System.Collections;

public class Repeal : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D collider)
	{
        if (collider.CompareTag("Coin"))
            return;
		if (collider.gameObject.rigidbody2D)
		{
			collider.gameObject.rigidbody2D.AddForceAtPosition((Vector2)(collider.transform.position - transform.position)*500,(Vector2)transform.position);
		}
	}
}
