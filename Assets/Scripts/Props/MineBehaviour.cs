using UnityEngine;
using System.Collections;

public class MineBehaviour : MonoBehaviour
{
    public Sprite mineState;
	public ParticleSystem groundExplosion;
	public AudioClip v;

    private Sprite originalMineState;

    void Spawned ()
    {
        originalMineState = GetComponent<SpriteRenderer>().sprite;
    }
	void OnCollisionEnter2D (Collision2D collision)
	{
        audio.Play();
		if (collision.transform.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(v, transform.position, 1f);
            NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage");
            PoolManager.Pools["fx"].Spawn(groundExplosion, transform.position, Quaternion.identity);
            if (PlayerStatus.playerStatus.lives > 0)
                iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));
            PoolManager.Pools["props"].Despawn(transform);
		}
        if (collision.transform.tag == "Ground")
        {
            GetComponent<SpriteRenderer>().sprite = mineState;
            transform.rotation = Quaternion.identity;
            rigidbody2D.isKinematic = true;
        }

        if (collision.transform.tag == "Gift" || collision.transform.tag == "Rocket")
        {
            PoolManager.Pools["fx"].Spawn(groundExplosion, transform.position, Quaternion.identity);
            PoolManager.Pools["props"].Despawn(transform);
        }
    }

    void OnDespawned ()
    {
        rigidbody2D.isKinematic = false;
        GetComponent<SpriteRenderer>().sprite = originalMineState;
    }
}