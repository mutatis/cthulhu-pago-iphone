﻿using UnityEngine;
using System;

public class RigidBody2DBidirectionFixedFlying : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;			// For determining which way the player is currently facing.
    [HideInInspector]
    public float h = 1;			// For determining which way the player is currently facing.
    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 20f;				// The fastest the player can travel in the x axis.


    void FixedUpdate()
    {
//		transform.Translate(0.5f, 0f, 0f);

        // Cache the horizontal input.
        //h = Input.GetAxis("Horizontal");

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        /*if (h * rigidbody2D.velocity.x < maxSpeed)
        {
            // ... add a force to the player.
            //rigidbody2D.AddForce(Vector2.right * h * moveForce);
			rigidbody2D.velocity = new Vector2(maxSpeed, rigidbody2D.velocity.y);

        }

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
        {
            // ... set the player's velocity to the maxSpeed in the x axis.
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
        }*/
        rigidbody2D.velocity = new Vector2 (maxSpeed, rigidbody2D.velocity.y);
        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();
    }


    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}