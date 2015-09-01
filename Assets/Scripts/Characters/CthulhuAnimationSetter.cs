//
// CthulhuAnimationSetter.cs
//
// Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//
// Copyright (c) 2014 Yves J. Albuquerque
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using UnityEngine;
using System.Collections;
/// <summary>
/// Cthulhu animation setter.
/// </summary>
/// <remarks>
/// Animates player`s arm, head and body
/// </remarks>
public class CthulhuAnimationSetter : MonoBehaviour
{
    static public CthulhuAnimationSetter cthulhuAnimationSetter; //Singleton
    private RigidBody2DUnidirectional rigidBody2DUnidirectional; //Rigidbody2D Reference
    private Jump2D jump2d; //Jump2D reference

    public Animator bodyAnimator;					// Reference to the player's animator component.
    public Animator headAnimator;					// Reference to the player's animator component.
    public Animator armAnimator;                    // Reference to the player's animator component.
	public Animator tentAnimator;
	public Animator bracoDAnimator;
	bool oprimi;
	CircleCollider2D circle;
	int random;
	public GameObject martin;
	public GameObject tent;
	public AudioClip[] die;

/// <summary>
/// Awake this instance.
/// </summary>
    void Awake()
    {
        // Setting up references.
		circle = GetComponent<CircleCollider2D> ();
        rigidBody2DUnidirectional = GetComponent<RigidBody2DUnidirectional>();
        cthulhuAnimationSetter = GetComponent<CthulhuAnimationSetter>();
        jump2d = GetComponent<Jump2D>();
        NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");
    }

	void Start()
	{
		if(PlayerStatus.playerStatus.lives > 1)
		{
			oprimi = true;
		}
		bodyAnimator.SetBool ("Pika", true);
	}

/// <summary>
/// Update this instance.
/// </summary>
    void Update ()
    {
		if(PlayerStatus.playerStatus.kk)
		{
			headAnimator.SetTrigger("Porra");
		}
		else if(PlayerStatus.playerStatus.lives <= 1 && oprimi)
		{
			headAnimator.SetBool("Oprimido", true);
		}

		else if(PlayerStatus.playerStatus.lives <= 0 && rigidbody2D.velocity.y <= 0.01f)
		{
			bodyAnimator.SetBool("Grounded", true);
			headAnimator.SetBool("Grounded", true);
		}

        if (bodyAnimator)
        {
            bodyAnimator.SetFloat("hSpeed", Mathf.Abs(rigidbody2D.velocity.x));     // The Speed animator parameter is set to the absolute value of the horizontal input.
            bodyAnimator.SetFloat("vSpeed", rigidbody2D.velocity.y);     // The Speed animator parameter is set to the absolute value of the horizontal input.
            bodyAnimator.SetBool("Grounded", jump2d.grounded); //Update grounded bool that controls player ground animation - maybe some optimization can be done here
        }
	        if (headAnimator)
	        {
	            headAnimator.SetFloat("vSpeed", rigidbody2D.velocity.y);
	            headAnimator.SetBool("Grounded", jump2d.grounded); //Update grounded bool that controls player ground animation - maybe some optimization can be done here
	        }
	
	        if (armAnimator)
	        {
	            armAnimator.SetFloat("vSpeed", rigidbody2D.velocity.y);
	            armAnimator.SetBool("Grounded", jump2d.grounded);
	            //if (Input.GetButtonDown("Fire1"))
	                //armAnimator.SetTrigger("Attack");
	        }
		if(UserControl.userControl.indi != 1)
			bracoDAnimator.SetFloat ("vSpeed", rigidbody2D.velocity.y);


		tent.SetActive(true);
		//headAnimator.SetBool("Falling", bodyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Falling"));
	}

/// <summary>
/// LateUpdate
/// </summary>
    void LateUpdate()
    {
        if (jump2d.triggerToJump && PlayerStatus.playerStatus.lives > 0) //if player will jump or doublejump
        {
			if (jump2d.grounded)
			{
				bodyAnimator.SetTrigger("Jump");        // Set the Jump animator trigger parameter.
				if(UserControl.userControl.indi != 1)
					bracoDAnimator.SetTrigger("Jump");
				headAnimator.SetTrigger("Jump");
			
                	if (armAnimator)
                    	armAnimator.SetTrigger("Jump");
				
			}
			if (jump2d.isJumping && !jump2d.hadDoubleJumped)
			{
	            bodyAnimator.SetTrigger("DoubleJump");        // Set the DoubleJump animator trigger parameter.
				if(UserControl.userControl.indi != 1)
					bracoDAnimator.SetTrigger("Jump");
					headAnimator.SetTrigger("Jump");        // Set the DoubleJump animator trigger parameter.
	                if (armAnimator)
	                    armAnimator.SetTrigger("Jump");


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


	        if (coll.gameObject.tag == "Bomb" || coll.gameObject.tag == "Rocket" || coll.gameObject.tag == "Laser")
			{	
	            headAnimator.SetTrigger("Hit"); //play hit animation because player collided with something bad
				tentAnimator.SetTrigger("Hit"); //play hit animation because player collided with something bad
			}

	        if (coll.gameObject.tag == "Coin" || coll.gameObject.tag == "Gift")
			{
				headAnimator.SetTrigger("Surprised"); //play Surprised animation because player collided with something good
				tentAnimator.SetTrigger("Hit"); //play Surprised animation because player collided with something good
			}

		bodyAnimator.SetBool("Jump", false);
		bodyAnimator.SetBool("DoubleJump", false);
    }

/// <summary>
/// Raises the dead event.
/// </summary>
	public IEnumerator Dying ()
	{
		PlayerPrefs.SetInt ("Galinhas", 0);
		headAnimator.SetTrigger("Dead");
		if(UserControl.userControl.indi != 1)
			bracoDAnimator.SetTrigger("Dead");
		bodyAnimator.SetBool("Dead", true); //play dead animation because player...well... has passed way
		random = Random.Range (0,2);
		if(random == 0)
		{
			circle.radius = 0.7f;
			if(PlayerStatus.playerStatus.idol == 1)
			{
				AudioSource.PlayClipAtPoint(die[1], transform.position, 1f); 
			}
			else
			{
				AudioSource.PlayClipAtPoint(die[0], transform.position, 1f); 
			}
			//Destroy(tent.gameObject);
		}
		headAnimator.SetBool("Dead", true); //play dead animation because player...well... has passed way
		if (armAnimator)
			armAnimator.SetBool("Dead", true); //play dead animation because player...well... has passed way
		bodyAnimator.SetInteger("NDead", random);
		if(PlayerPrefs.GetString("Controle") != "abdown")
		{
			headAnimator.SetInteger ("NDead", random);
		}
		else
		{
			headAnimator.SetInteger ("NDead", 2);
		}
		if(UserControl.userControl.indi != 1)
			bracoDAnimator.SetInteger("NDead", random);


        jump2d.enabled = false;
		if(random != 0)
			circle.radius = 2.3f;

        while (true)
        {
            if (rigidBody2DUnidirectional.maxSpeed > 0)
            {
				if(random != 1)
				{
                	rigidBody2DUnidirectional.maxSpeed -= 1f;
				}
				else
				{
					rigidBody2DUnidirectional.maxSpeed = rigidBody2DUnidirectional.maxSpeed/1.3f;
					yield return new WaitForSeconds(1f);
					rigidBody2DUnidirectional.maxSpeed = 0f;
				}
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
		bodyAnimator.SetBool("Dead", true); //play dead animation because player...well... has passed way
		bodyAnimator.SetInteger("NDead", random); 

	        headAnimator.SetBool("Dead", true); //play dead animation because player...well... has passed way
	        if (armAnimator)
	            armAnimator.SetBool("Dead", true);

    }
	public void Retry()
	{
		bodyAnimator.SetBool("Dead", false); //play dead animation because player...well... has passed way

			headAnimator.SetBool("Dead", false); //play dead animation because player...well... has passed way
			if (armAnimator)
			armAnimator.SetBool("Dead", false);

	}
}