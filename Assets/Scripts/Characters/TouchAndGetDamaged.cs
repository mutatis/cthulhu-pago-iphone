using UnityEngine;
using System.Collections;

public class TouchAndGetDamaged : MonoBehaviour
{
	public ParticleSystem damageEffect;

	IEnumerator OnCollisionEnter2D (Collision2D collision)
	{

        yield return new WaitForEndOfFrame();

		if (collision.transform.tag == "Player")
		{
			Transform effect = damageEffect.transform;
			PoolManager.Pools["fx"].Spawn(effect, collision.contacts[0].point, effect.rotation);
			NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
		}
	}

    IEnumerator OnTriggerEnter2D (Collider2D collider)
    {
        yield return new WaitForEndOfFrame();
        
        if (collider.transform.tag == "Player")
        {
            Transform effect = damageEffect.transform;
            PoolManager.Pools["fx"].Spawn(effect, collider.transform.position, effect.rotation);
            NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
        }
    }
}
