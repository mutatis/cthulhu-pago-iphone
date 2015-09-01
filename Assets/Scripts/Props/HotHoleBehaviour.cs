using UnityEngine;
using System.Collections;

public class HotHoleBehaviour : MonoBehaviour
{
	public GameObject damageEffect;
	public float force;


	IEnumerator OnTriggerEnter2D (Collider2D collider)
	{
		yield return new WaitForEndOfFrame();
		
		if (collider.transform.tag == "Player")
		{
            if (PlayerStatus.playerStatus.lives <= 0)
                return false;
			Transform effect = PoolManager.Pools["fx"].Spawn(damageEffect.transform, collider.transform.position + new Vector3(0,2,0), damageEffect.transform.rotation);
			effect.parent = collider.transform;
			NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
            collider.transform.root.rigidbody2D.AddForce(Vector2.up * force);
		}
	}
}
