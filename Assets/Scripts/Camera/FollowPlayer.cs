//  FollowPlayer.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       18-12-2013 

using UnityEngine;
using System.Collections;

/// <summary>
/// Follow player.
/// </summary>
/// <remarks>
/// Follows a object with tag Player in X axis
/// </remarks>
public class FollowPlayer : MonoBehaviour
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
    public float smoothTime = 0.3F; //Makes this behaviour smooth
    private float xPosition; //wanted X position
    private float yPosition; //wanted Y position
    private Vector3 velocity = Vector3.zero; //A reference value used by SmoothDamp that tracks this object velocity
    private Transform player; // Reference to the player.

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
        xPosition = player.position.x + offset.x;
        yPosition = offset.y;

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(xPosition, yPosition, transform.position.z), ref velocity, smoothTime);
	}

/*
    void CorrectPosition ()
    {
        transform.position = new Vector3(xPosition, offset.y, 0);
    }*/ // Not sure what it was for...
}
