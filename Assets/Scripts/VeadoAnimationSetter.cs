using UnityEngine;
using System.Collections;

public class VeadoAnimationSetter : MonoBehaviour {
	
	static public VeadoAnimationSetter veadoAnimationSetter; //Singleton
	private RigidBody2DUnidirectional rigidBody2DUnidirectional; //Rigidbody2D Reference
	private Jump2D jump2d; //Jump2D reference

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		// Setting up references.
		rigidBody2DUnidirectional = GetComponent<RigidBody2DUnidirectional>();
		veadoAnimationSetter = GetComponent<VeadoAnimationSetter>();
		jump2d = GetComponent<Jump2D>();
		NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");
	}
	
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		
	}
	
	/// <summary>
	/// LateUpdate
	/// </summary>
	void LateUpdate()
	{

	}
	
	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="coll">Collision2D</param>
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (PlayerStatus.playerStatus.lives <= 0)
			return;
		
		if (PlayerStatus.playerStatus.invulnerable)
			return;

	}
	
	/// <summary>
	/// Raises the dead event.
	/// </summary>
	public IEnumerator Dying ()
	{
		
		jump2d.enabled = false;
		
		
		while (true)
		{
			if (rigidBody2DUnidirectional.maxSpeed > 0)
			{
				//rigidBody2DUnidirectional.maxSpeed -= 1f;
				jump2d.hitTheGroundParticleEffect.Play();
			}
			else
			{
				rigidBody2DUnidirectional.maxSpeed = 0;
				break;
			}
			yield return new WaitForSeconds(0.1f);
		}
		collider2D.enabled = false;
		
	}
	public void Retry()
	{
		
	}
}