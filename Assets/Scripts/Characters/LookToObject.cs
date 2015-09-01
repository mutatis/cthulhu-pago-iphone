//
// LookToObject.cs
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
/// Look to object.
/// </summary>
public class LookToObject : MonoBehaviour
{
    public Transform targetObject;
    public float damping = 6.0f;

	// Update is called once per frame
	void Update ()
    {
		if (!targetObject)
			return;

		if (SantaBehaviour.santa.santaStates == SantaBehaviour.SantaStates.BeforeEnter || 
		    SantaBehaviour.santa.santaStates == SantaBehaviour.SantaStates.Entering) //gambiarra
			return;

        Vector3 relativePos = targetObject.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        rotation.x = 0;
        rotation.y = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
	}
}
