using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class SuperCthulhuAnimationSetter : MonoBehaviour
{
    public Animator bodyAnimator;					// Reference to the player's animator component.
    public Animator headAnimator;					// Reference to the player's animator component.
	public Transform super;
	public static SuperCthulhuAnimationSetter supercthulhu;
	bool dead;

    void Awake()
    {
		supercthulhu = this;
        // Setting up references.
      //  bodyAnimator = GetComponent<Animator>();
		NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");

    }
	
	// Update is called once per frame
	void Update ()
    {
		transform.position = super.position;
		bodyAnimator.SetFloat("vSpeed", rigidbody2D.velocity.y);     // The Speed animator parameter is set to the absolute value of the horizontal input.
		if(dead)
		{
			Debug.Log("Dead");
			rigidbody2D.velocity = new Vector2(0, -1);
		}
	}

	/// <summary>
	/// Receives the damage.
	/// </summary>
	void ReceiveDamage ()
	{
		headAnimator.SetTrigger("Hit"); //play hit animation because player collided with something
	}
    /*void OnCollisionEnter2D(Collision2D coll)
    {
		//bodyAnimator.SetTrigger("Hit"); //play hit animation because player collided with something
		headAnimator.SetTrigger("Hit"); //play hit animation because player collided with something
    }*/
}