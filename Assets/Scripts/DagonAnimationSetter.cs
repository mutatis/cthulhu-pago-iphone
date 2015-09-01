using UnityEngine;
using System.Collections;

public class DagonAnimationSetter : MonoBehaviour {

	static public DagonAnimationSetter dagonAnimationSetter; //Singleton
	private RigidBody2DUnidirectional rigidBody2DUnidirectional; //Rigidbody2D Reference
	private Jump2D jump2d; //Jump2D reference
	
	private Animator bodyAnimator;					// Reference to the player's animator component.
	public AudioClip[] die;
	public GameObject martin;
	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		// Setting up references.
		rigidBody2DUnidirectional = GetComponent<RigidBody2DUnidirectional>();
		dagonAnimationSetter = GetComponent<DagonAnimationSetter>();
		jump2d = GetComponent<Jump2D>();
		bodyAnimator = GetComponent<Animator>();
		NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");
	}
	
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		if (bodyAnimator)
		{
			bodyAnimator.SetFloat("hSpeed", Mathf.Abs(rigidbody2D.velocity.x));     // The Speed animator parameter is set to the absolute value of the horizontal input.
			bodyAnimator.SetFloat("vSpeed", rigidbody2D.velocity.y);     // The Speed animator parameter is set to the absolute value of the horizontal input.
			bodyAnimator.SetBool("Grounded", jump2d.grounded); //Update grounded bool that controls player ground animation - maybe some optimization can be done here
		}
		if(transform.position.y <= PlayerStatus.playerStatus.sombraBomb.position.y)
		{
			transform.position = new Vector3 (transform.position.x, PlayerStatus.playerStatus.sombraBomb.position.y, transform.position.z);
		}
	}
	
	/// <summary>
	/// LateUpdate
	/// </summary>
	void LateUpdate()
	{
		if (jump2d.triggerToJump) //if player will jump or doublejump
		{
			if (jump2d.grounded)
			{
				bodyAnimator.SetTrigger("Jump");        // Set the Jump animator trigger parameter.
				
			}
			if (jump2d.isJumping && !jump2d.hadDoubleJumped)
			{
				bodyAnimator.SetTrigger("DoubleJump");        // Set the DoubleJump animator trigger parameter.
				
			}
		}
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
				
		bodyAnimator.SetBool("Jump", false);
		bodyAnimator.SetBool("DoubleJump", false);
	}
	
	/// <summary>
	/// Raises the dead event.
	/// </summary>
	public IEnumerator Dying ()
	{
		bodyAnimator.SetBool("Dead", true); //play dead animation because player...well... has passed way
				
		jump2d.enabled = false;
		
		while (true)
		{
			if (rigidBody2DUnidirectional.maxSpeed > 0)
			{
				rigidBody2DUnidirectional.maxSpeed -= 1;
				jump2d.hitTheGroundParticleEffect.Play();
			}
			else
			{
				rigidBody2DUnidirectional.maxSpeed = 0;
				break;
			}
			yield return new WaitForSeconds(0.1f);
		}
		if(PlayerPrefs.GetInt("Kill") == 5 || PlayerPrefs.GetInt("Kill") == 2)
		{
			martin.SetActive (false);
		}
		//collider2D.enabled = false;
		bodyAnimator.SetBool("Dead", true); //play dead animation because player...well... has passed way
		
	}
	public void Retry()
	{
		bodyAnimator.SetBool("Dead", false); //play dead animation because player...well... has passed way
		
	}
}
