//  UpdatePositionOnEvent.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       12-01-2014 

using UnityEngine;
using System.Collections;


/// <summary>
/// Update position on event.
/// </summary>
/// <remarks>
/// Update position based on camera position OnEvent
/// </remarks>
public class UpdatePositionOnEvent : UI_PopOnEventBase
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
    private Transform target; // Reference to the player.

    public override void Start ()
    {
        target = Camera.main.transform;
    }
    
    public override void OnDead ()
    {
        transform.position = target.position + offset;
    }
    
    public override void OnPause ()
    {
        transform.position = target.position + offset;
    }

    public override void OnResume ()
    {
    }
}
