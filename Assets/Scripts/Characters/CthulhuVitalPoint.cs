using UnityEngine;
using System.Collections;

public class CthulhuVitalPoint : MonoBehaviour
{
	public ParticleSystem damageEffect;

	void OnCollisionEnter2D (Collision2D collision)
	{
        if (collider.gameObject.layer == LayerMask.NameToLayer("IgnoreCollision") ||
            collider.gameObject.layer == LayerMask.NameToLayer("Pickups"))
            return;
        print(collision.collider.name);
        if (damageEffect)
        {
  			Transform effect = damageEffect.transform;
   			PoolManager.Pools["fx"].Spawn(effect, collision.contacts[0].point, effect.rotation);
         }
		NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
	}

    void OnTriggerEnter2D (Collider2D collider)
    {

        if (collider.gameObject.layer == LayerMask.NameToLayer("IgnoreCollision") ||
            collider.gameObject.layer == LayerMask.NameToLayer("Pickups"))
            return;

        if (damageEffect)
        {
            Transform effect = damageEffect.transform;
            PoolManager.Pools["fx"].Spawn(effect, collider.transform.position, effect.rotation);
        }
        NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
    }
}
