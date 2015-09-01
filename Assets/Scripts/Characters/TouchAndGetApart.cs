using UnityEngine;
using System.Collections;

public class TouchAndGetApart : MonoBehaviour
{
    //public float force = 3;
    public float radius = 2;
    Collider2D[] colliders;

    void OnCollisionEnter2D (Collision2D coll)
	{
		colliders = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (Collider2D c in colliders)
		{
            if (c.rigidbody2D)
                c.rigidbody2D.AddForce(transform.position-c.transform.position);
		}
	}
}