using UnityEngine;
using System.Collections;

public class Repeleplayer : MonoBehaviour
{
	private Transform player; // Reference to the player.
	private Vector2 direction;
	private Vector2 direction2;
	float time;
	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake ()
	{
		// Setting up the reference.
		player = PlayerStatus.playerStatus.transform;
	}
	
	void Start()
	{
		time = Time.time + 3.6f;
	}
	
	/// <summary>
	/// SmoothDamp is used in FixedUpdate to avoid glitchs caused by non-linear equation
	/// </summary>
	void FixedUpdate ()
	{
		direction = (Vector2)(transform.position - player.position);
		direction.Normalize();
		direction *= (2*player.rigidbody2D.velocity.x);
		direction2 = (player.position - transform.position);
		direction2.Normalize();
		if (rigidbody2D.velocity.magnitude > 200)
			rigidbody2D.velocity = direction;
		if(time <= Time.time)
		{
			transform.Translate(direction2);
		}
		else
		{
			rigidbody2D.AddForce(direction);
		}
		//StartCoroutine("Circle");
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!gameObject.activeSelf)
			return;
		if (other.tag != "Player")
			return;
		GameManager.gameManager.RemoveCoin();		
		//PoolManager.Pools["props"].Despawn(transform);
	}
}
