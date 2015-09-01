//  BombBehaviour.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       19-12-2013 

using UnityEngine;
using System.Collections;

/// <summary>
/// Bomb behaviour.
/// </summary>
/// <remarks>
/// Put this code in the Bomb so it will explode and send notifications
/// </remarks>
public class BombBehaviour : MonoBehaviour
{
	public ParticleSystem groundExplosion;
	public ParticleSystem aerialExplosion;
	public AudioClip v;

	IEnumerator OnCollisionEnter2D (Collision2D collision)
	{
        audio.Play();

		yield return new WaitForEndOfFrame();

		if (collision.transform.tag == "Ground")
		{
			AudioSource.PlayClipAtPoint(v, transform.position, 1f);
			GameObject effect = groundExplosion.gameObject;
			if (transform.position.x > PlayerStatus.playerStatus.transform.position.x)
				NotificationCenter.DefaultCenter().PostNotification(this,"IncreaseStrength");
			else
				NotificationCenter.DefaultCenter().PostNotification(this,"DecreaseStrength");

            PoolManager.Pools["fx"].Spawn(effect.transform, transform.position, Quaternion.identity);
            //if (PlayerStatus.playerStatus.lives > 0)
			    //iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));

            PoolManager.Pools["props"].Despawn(transform);
			return false;
		}

		if (collision.transform.tag == "Gift" || collision.transform.tag == "Rocket")
		{
			GameObject effect = aerialExplosion.gameObject;
			PoolManager.Pools["fx"].Spawn(effect.transform, transform.position, Quaternion.identity);
			/*if (PlayerStatus.playerStatus.lives > 0)
			{
				iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));
			}*/
			PoolManager.Pools["props"].Despawn(transform);
			return false;
			//NotificationCenter.DefaultCenter().PostNotification(this,"TooNarrow", transform.position);
		}


		if (collision.transform.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(v, transform.position, 1f);
			GameObject effect = aerialExplosion.gameObject;
            PoolManager.Pools["fx"].Spawn(effect.transform, transform.position, Quaternion.identity);
            NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage");
            if (PlayerStatus.playerStatus.lives > 0)
            {
                iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));
            }
            PoolManager.Pools["props"].Despawn(transform);
			return false;
		}
	}
}
