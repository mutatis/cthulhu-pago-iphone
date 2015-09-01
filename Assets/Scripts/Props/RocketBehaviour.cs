using UnityEngine;
using System.Collections;

public class RocketBehaviour : MonoBehaviour
{
	public float acceleration = 100;
	bool ok;
    public AudioClip explosionSFX;
	public GameObject groundExplosion;
	public GameObject aerialExplosion;
	public int type;
	public AudioClip mcaw;

    void FixedUpdate ()
	{
		if(PlayerPrefs.GetInt("dificuldade") == 1 && ok == false)
		{
			acceleration = 10;
			ok = true;
		}

		if (transform.position.x < PlayerStatus.playerStatus.transform.position.x)
			return;

        rigidbody2D.AddForce(acceleration * transform.TransformDirection(-Vector3.right));
	}

	IEnumerator OnCollisionEnter2D (Collision2D collision)
	{
		yield return new WaitForEndOfFrame();
		if(type == 1)
		{
			AudioSource.PlayClipAtPoint(mcaw, transform.position, 1f);
		}
        AudioSource.PlayClipAtPoint(explosionSFX, transform.position, 0.5f);
		if (collision.transform.tag == "Ground")
		{
            PoolManager.Pools["fx"].Spawn(groundExplosion.transform, transform.position, Quaternion.identity);
			//iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));
            PoolManager.Pools["props"].Despawn(transform);
			return false;
		}

		if (collision.transform.tag == "Gift" || collision.transform.tag == "Laser")
		{
			PoolManager.Pools["fx"].Spawn(aerialExplosion.transform, transform.position, Quaternion.identity);
			PoolManager.Pools["props"].Despawn(transform);
			return false;
		}
		
		if (collision.transform.tag == "Player")
		{
            PoolManager.Pools["fx"].Spawn(aerialExplosion.transform, transform.position, Quaternion.identity);
			//NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
            NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage");

			iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));

            PoolManager.Pools["props"].Despawn(transform);
			return false;
		}
		if(collision.gameObject.tag == "Bomb")
		{
			Destroy(gameObject);
		}
	}
}