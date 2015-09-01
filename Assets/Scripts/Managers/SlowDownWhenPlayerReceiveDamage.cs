//
// SlowDownWhenPlayerReceiveDamage.cs
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

/// <summary>
/// Slow down when player receive damage.
/// </summary>
public class SlowDownWhenPlayerReceiveDamage : MonoBehaviour
{
    private FollowTarget followTarget; //followTarget reference
	// Use this for initialization
	void Start ()
	{
		NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");
        followTarget = GetComponent<FollowTarget>();
	}
    /// <summary>
    /// Event called when player receives the damage.
    /// </summary>
	void ReceiveDamage ()
	{
        if (PlayerStatus.playerStatus.lives <= 0)
            followTarget.smoothTime = 0f;
        else
		    SlowDownCamera();
	}
    /// <summary>
    /// Slows down camera.
    /// </summary>
	void SlowDownCamera ()
	{
        if (followTarget.smoothTime > 0.2f)
        {
            followTarget.smoothTime -= 0.1f;
        }
        else
        {
            followTarget.smoothTime = 0.2f;
        }
	}
}
