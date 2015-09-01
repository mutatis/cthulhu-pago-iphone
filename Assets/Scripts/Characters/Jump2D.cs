//  Jump2D.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       18-12-2013 

using System;
using UnityEngine;

/// <summary>
/// Jump2d. Jumps a 2D character.
/// </summary>
/// <remarks>
/// Put this script at your 2D character to be abble to jump.
/// </remarks>
public class Jump2D : MonoBehaviour
{	
    public LayerMask layerMask;
    public float jumpForce = 40;			// Amount of force added when the player jumps.
    public GameObject jumpParticleEffect;    //Particle emmited when character jump
    public GameObject doubleJumpParticleEffect;    //Particle emmited when character jump
	public ParticleSystem hitTheGroundParticleEffect;    //Particle emmited when character jump
	public GameObject hitTheGroundCrater;    //Particle emmited when character jump
	int x;

    public AudioClip jumpSFX;			    // Audioclip for when the player jumps.
    public AudioClip doubleJumpSFX;			    // Audioclip for when the player jumps.
    public AudioClip hitTheGroundSFX;	    // Audioclip for when the player hit the floor again.

    [HideInInspector]
    public bool triggerToJump = false;				// Condition for whether the player should jump.
    [HideInInspector]
    public bool isJumping = false;            //True while character is in the air
    [HideInInspector]
    public bool grounded = false;			// Whether or not the player is grounded.
    [HideInInspector]
    public bool hadDoubleJumped = false;		// True if can doublejump now

    private Transform groundCheck;			// A position marking where to check if the player is grounded.
	public static Jump2D jump2D;
	int random;

    /// <summary>
    /// Set some references
    /// </summary>
    void Awake()
    {
		jump2D = this;
        groundCheck = transform.Find("groundCheck");        // Setting up references.
    }
		
	void Start()
	{
		if(PlayerPrefs.GetInt("JumpMore") < 2)
		{
			PlayerPrefs.SetInt("JumpMore", 2);
		}
		x = PlayerPrefs.GetInt("JumpMore");
		Debug.Log(x);
	}

    void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, layerMask);        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.

        if (grounded && isJumping)//if the player returned to te ground
        {
			x = PlayerPrefs.GetInt("JumpMore");
            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Liquid")))        // If theres a Liquid above then return
                return;

            if (hitTheGroundCrater)//if this player has a hitTheGroundParticleEffect
            {
                PoolManager.Pools["fx"].Spawn(hitTheGroundCrater.transform, transform.position + new Vector3(1, 0, 0), transform.rotation);//PoolManager.Pools["fx"].Spawns our hitTheGroundParticleEffect
                hitTheGroundParticleEffect.Play();
                //PoolManager.Pools["fx"].Spawn(hitTheGroundParticleEffect, transform.position + new Vector3(1f, 1f, 0f), Quaternion.identity); //Arrumar a rotacao <----------------------
            }

            if (hitTheGroundSFX)//if this player has a hitTheGroundSFX
                AudioSource.PlayClipAtPoint(hitTheGroundSFX, transform.position, 1f);   // Play our hitTheGroundSFX audio clip.

            isJumping = false; //So they are not jumping anymore
            hadDoubleJumped = false; //Not Doublejump either
        }

        isJumping = !grounded; // Say that the player is in the air
    }

    public void Jump ()
    {
		if (x > 0) //If the player is on the ground...
		{
			triggerToJump = true; // Jump
			return;
		}
		
		if(x > 0)
		{
			if (isJumping && !hadDoubleJumped)
			{
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
				triggerToJump = true; // Do a DoubleJump
			}
		}
    }

	public void JumpIndi()
	{
		if (grounded) //If the player is on the ground...
		{
			triggerToJump = true; // Jump
			return;
		}
		
		if(x > (PlayerPrefs.GetInt("JumpMore") - 2))
		{
			if (isJumping && !hadDoubleJumped)
			{
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
				triggerToJump = true; // Do a DoubleJump
			}
		}
	}

    public void StopJump ()
    {
        rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y/2);
    }

/// <summary>
/// Fixed update of this class.
/// </summary>
    void FixedUpdate()
    {
        if (triggerToJump)   // If the player should jump...
        {
			if (grounded) //if regular jump
            {
                if (jumpParticleEffect)
				{
                    PoolManager.Pools["fx"].Spawn(jumpParticleEffect.transform, transform.position + new Vector3(2.5f, 1f, 0f), transform.rotation);
				}
                if (jumpSFX) //if this player has a JumpSFX
				{
					//random = Random.Range(0, 2);
                    AudioSource.PlayClipAtPoint(jumpSFX, transform.position, 1f);   // Play our jumpSFX audio clip.
				}
				rigidbody2D.velocity = new Vector2(0f, jumpForce);   // Add a vertical force to the player.
            }
			else if(x > 0)
			{
				if (isJumping && !hadDoubleJumped)
	            {
	                if (doubleJumpParticleEffect)
	                    PoolManager.Pools["fx"].Spawn(doubleJumpParticleEffect.transform, transform.position + new Vector3(0, 1, 0), transform.rotation);
	                if (doubleJumpSFX) //if this player has a JumpSFX
					{
	                    AudioSource.PlayClipAtPoint(doubleJumpSFX, transform.position, 1f);   // Play our jumpSFX audio clip.
					}
	                //hadDoubleJumped = true; //had double jumped
					rigidbody2D.velocity = new Vector2(0f, jumpForce);   // Add a vertical force to the player.
					//rigidbody2D.AddForce(new Vector2(0f, jumpForce));   // Add a vertical force to the player.
				}
			}
			x--;
        }
        triggerToJump = false;  // Make sure the player can't jump again until the jump conditions from Update are satisfied.
    }
}
