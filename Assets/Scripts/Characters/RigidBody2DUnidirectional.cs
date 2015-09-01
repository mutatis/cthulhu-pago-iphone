//
// RigidBody2DUnidirectional.cs
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
/// Rigidbody2D unidirectional movement behaviour.
/// </summary>
public class RigidBody2DUnidirectional : MonoBehaviour
{
    public bool autoMove = true; // the player automatically moves if this is true
    public Axis axisToMove; //Axis to player movement

    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 20f;			// The fastest the player can travel in the x axis.

    public bool hasLimit = false;   //true if this movement has limit
    public float upperLimit = 10; //upper Limit
    public float bottomLimit = -10; //BottomLimit

    void FixedUpdate ()
    {
        if (autoMove)
        {
            if (axisToMove ==  Axis.x)
                rigidbody2D.velocity = new Vector2 (maxSpeed, rigidbody2D.velocity.y);
            else
                rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, maxSpeed);
            return;
        }
    }

    public void Move (float inputForce)
    {
        if (autoMove)
            return;

        inputForce = ApplyLimits (inputForce);
        if (axisToMove ==  Axis.x && rigidbody2D.velocity.x < maxSpeed)
        {
            rigidbody2D.AddForce(new Vector2 (inputForce * moveForce, 0));
            return;
        }
        
        if (axisToMove ==  Axis.y && rigidbody2D.velocity.y < maxSpeed)
        {
            rigidbody2D.AddForce(new Vector2 (0, inputForce * moveForce));
            return;
        }
    }

    float ApplyLimits (float inputForce)
    {
        if (hasLimit)
        {
            if (axisToMove ==  Axis.x)
            {
                if (transform.position.x > upperLimit && inputForce > 0)
                    inputForce = -0.2f;
                if (transform.position.x < bottomLimit && inputForce < 0)
                    inputForce = 0.2f;
            }
            else
            {
                if (transform.position.y > upperLimit && inputForce > 0)
                    inputForce = -0.2f;
                if (transform.position.y < bottomLimit && inputForce < 0)
                    inputForce = 0.2f;
            }
        }
        return inputForce;
    }
}