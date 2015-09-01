using UnityEngine;
using System.Collections;

public class FlyingRock : MonoBehaviour
{
	public GameObject myPieces;
	public bool GiveDamage;
	public bool GiveBonus;
	public AudioClip sfx;

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (myPieces)
		{
        	PoolManager.Pools["props"].Spawn (myPieces.transform,transform.position,transform.rotation);
			if (GiveBonus)
				GameManager.gameManager.AddCoin();
		}
		if(GiveDamage && collision.gameObject.CompareTag("Player"))
			NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
		if (sfx)
            AudioSource.PlayClipAtPoint(sfx, transform.position, 1f);
		PoolManager.Pools["props"].Despawn (transform);
	}
}
