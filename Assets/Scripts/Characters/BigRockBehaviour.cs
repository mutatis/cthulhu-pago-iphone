using UnityEngine;
using System.Collections;

/// <summary>
/// Follow player.
/// </summary>
/// <remarks>
/// Follows a object with tag Player in X axis
/// </remarks>
public class BigRockBehaviour : MonoBehaviour
{
    public float distanceFromPlayer = 12;
    public ParticleSystem impactFx;
    private Transform player; // Reference to the player.
    private Vector2 direction;
    private float timeSinceLastEffect;
    private float timer;
	public AudioClip pedra;
	bool ok;

    /// <summary>
    /// Awake this instance.
    /// </summary>
	void Awake ()
	{
		// Setting up the reference.
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
    /// <summary>
    /// SmoothDamp is used in FixedUpdate to avoid glitchs caused by non-linear equation
    /// </summary>
	void FixedUpdate ()
	{
        if (player.transform.position.x > transform.position.x + distanceFromPlayer && player.transform.position.x < transform.position.x + (2*distanceFromPlayer))
        {
			if(ok == false)
			{
				AudioSource.PlayClipAtPoint (pedra, transform.position, 1f);
				ok = true;
			}
            rigidbody2D.isKinematic = false;
            if (rigidbody2D.velocity.x == 0)
            {
                rigidbody2D.velocity = player.rigidbody2D.velocity;
            }
            else
            {
                rigidbody2D.AddForce(Vector2.right);
            }
        }
	}

    void OnCollisionEnter2D (Collision2D collision)
    {
        PoolManager.Pools["fx"].Spawn(impactFx, collision.contacts[0].point, Quaternion.identity);

        if (collision.collider.name == "cave_entrance")
        {
            ParticleSystem[] particles = collision.gameObject.GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Play();
            }

            iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (2f,2f,2f), "islocal", true));
        }
    }

    void OnCollisionStay2D (Collision2D collision)
    {
        if ((player.transform.position.x - transform.position.x) > (2 * distanceFromPlayer))
            return;

        timer = Time.time;
        if (timer > timeSinceLastEffect + 0.2f)
        {
            timeSinceLastEffect = timer;

            for (int i = 0; i < collision.contacts.Length; i++)
                PoolManager.Pools ["fx"].Spawn(impactFx, collision.contacts [i].point, Quaternion.identity);
        }
    }
}
