using UnityEngine;
using System.Collections;

public class TouchAndDie : MonoBehaviour
{
	public ParticleSystem damageEffect;

	IEnumerator OnCollisionEnter2D (Collision2D collision)
	{
		yield return new WaitForEndOfFrame();

		if (collision.transform.tag == "Player")
		{
            //collision.collider.rigidbody2D.AddForce(transform.position-collision.transform.position);
		}
	}

    IEnumerator OnTriggerEnter2D (Collider2D collider)
    {
        yield return new WaitForEndOfFrame();
        
        if (collider.transform.tag == "Player")
        {
            collider.rigidbody2D.AddForce(transform.position-collider.transform.position);

        }
    }
}
