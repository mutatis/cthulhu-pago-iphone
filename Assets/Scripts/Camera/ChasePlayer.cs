//  ChasePlayer.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       19-02-2013 

using UnityEngine;
using System.Collections;

/// <summary>
/// Follow player.
/// </summary>
/// <remarks>
/// Follows a object with tag Player in X axis
/// </remarks>
public class ChasePlayer : MonoBehaviour
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
        direction = (Vector2)(player.position - transform.position);
        direction.Normalize();
        direction *= (player.rigidbody2D.velocity.x);
		direction2 = (player.position - transform.position);
		direction2.Normalize();
        if (rigidbody2D.velocity.magnitude > 200)
            rigidbody2D.velocity = direction;
		/*if(time <= Time.time)
		{*/
			transform.Translate(direction2);
		/*}
		else
		{
			rigidbody2D.AddForce(direction);
		}*/
		//StartCoroutine("Circle");
	}

	/*IEnumerator Circle()
	{
		rigidbody2D.AddForce(direction);
		yield return new WaitForSeconds (0.2f);
		transform.Translate(direction);
	}*/

/*
    void CorrectPosition ()
    {
        transform.position = new Vector3(xPosition, offset.y, 0);
    }*/ // Not sure what it was for...
}
