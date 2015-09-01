using UnityEngine;
using System.Collections;

public class OnTriggerGetDamaged : MonoBehaviour
{
	public ParticleSystem damageEffect;

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
