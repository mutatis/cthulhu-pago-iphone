//  BackgroundParallax.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//          based on BackgroundParallax code from Tower Defense 2D from unity
//  Last Update:
//       18-12-2013 

using UnityEngine;
using System.Collections;

/// <summary>
/// Background parallax.
/// </summary>
/// <remarks>
/// Put your transforms to be parallaxed in background. The parallax scale controls every parallax and the parallax reduction factor is multiplied for each of this transforms. Smooth is for attenuation.
/// </remarks>
public class BackgroundParallax : MonoBehaviour
{
	public Transform[] backgrounds;				// Array of all the backgrounds to be parallaxed.
	public float parallaxScale;					// The proportion of the camera's movement to move the backgrounds by.
	public float parallaxReductionFactor;		// How much less each successive layer should parallax.
	public float smoothing;						// How smooth the parallax effect should be.

	private Transform cam;						// Shorter reference to the main camera's transform.
	private Vector3 previousCamPos;				// The postion of the camera in the previous frame.

    /// <summary>
    /// Awake this instance and set our camera.
    /// </summary>
	void Awake ()
	{
		cam = Camera.main.transform;			// Setting up the reference shortcut.
	}
	
    /// <summary>
    /// Start to track the camera position.
    /// </summary>
	void Start ()
	{
		previousCamPos = cam.position; 			// The 'previous frame' had the current frame's camera position.
	}
    /// <summary>
    /// Then do the magic of parallax.
    /// </summary>
	void FixedUpdate ()
	{
		float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;		// The parallax is the opposite of the camera movement since the previous frame multiplied by the scale.

		for(int i = 0; i < backgrounds.Length; i++)			// For each successive background...
		{
			float backgroundTargetPosX = backgrounds[i].position.x + parallax * (i * parallaxReductionFactor + 1);		// ... set a target x position which is their current position plus the parallax multiplied by the reduction.
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);		// Create a target position which is the background's current position but with it's target x position.
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);				// Lerp the background's position between itself and it's target position.
		}

		previousCamPos = cam.position;  // Set the previousCamPos to the camera's position at the end of this frame.
	}
}
