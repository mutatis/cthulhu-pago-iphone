//
// AdjustCameraSize.cs
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
/// Adjust camera size on Pause and Die event.
/// </summary>
public class AdjustCameraSize : MonoBehaviour
{
    private Camera mainCamera; //main camera reference
    private Rect pausedRect; //rect size when in pause
    private Rect defaultRect; //default rect size

	// Use this for initialization
	void Awake ()
	{
        NotificationCenter notificationCenter = NotificationCenter.DefaultCenter();
        notificationCenter.AddObserver(this, "OnPause");
        notificationCenter.AddObserver(this, "OnDead");
        notificationCenter.AddObserver(this, "OnResume");

        mainCamera = Camera.main.camera;
        defaultRect = mainCamera.rect;
        pausedRect = new Rect (0f,0.2f,0.8f,1f);
	}

	void OnPause ()
    {
        mainCamera.rect = pausedRect;
    }

    void OnDead ()
    {
        mainCamera.rect = pausedRect;
    }

    void OnResume ()
    {
        mainCamera.rect = defaultRect;
    }
}
