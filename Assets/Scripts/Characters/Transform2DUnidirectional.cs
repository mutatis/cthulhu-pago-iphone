using UnityEngine;
using System;

public class Transform2DUnidirectional : MonoBehaviour
{
    public bool autoMove = true;
    public Axis axisToMove;
    public bool analogicInput;  //true if the input is analogic and has several degrees of movement
    public float inputForce = 1;			// the analogicForce
    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 20f;				// The fastest the player can travel in the x axis.
    public bool hasLimit = false;
    public float upperLimit = 10;
    public float lowerLimit = -10;

    void FixedUpdate()
    {
        if (autoMove)
        {
            if (axisToMove ==  Axis.x)
                transform.Translate(maxSpeed * Time.deltaTime, 0,0);
            else
                transform.Translate(0, maxSpeed * Time.deltaTime,0);
            return;
         }
        else
        {
            if (axisToMove == Axis.x)
                inputForce = Input.GetAxis("Horizontal"); // Cache the horizontal input.
            if (axisToMove == Axis.y)
                inputForce = Input.GetAxis("Vertical"); // Cache the vertical input.
        }

        if (!analogicInput)
        {
            if (inputForce > 0.1f)
            {
                inputForce = 1;
            }
            else if (inputForce < -0.1f)
            {
                inputForce = -1;
            }
            else
                inputForce = 0;
        }

        if (hasLimit)
        {
            if (axisToMove ==  Axis.x)
            {
                if (transform.position.x > upperLimit && inputForce > 0)
                    inputForce = -0.1f;
                if (transform.position.x < lowerLimit && inputForce < 0)
                    inputForce = 0.1f;
            }
            else
            {
                if (transform.position.y > upperLimit && inputForce > 0)
                    inputForce = -0.1f;
                if (transform.position.y < lowerLimit && inputForce < 0)
                    inputForce = 0.1f;
            }
        }

        if (axisToMove ==  Axis.x)
        {
            transform.Translate(inputForce * moveForce * Time.deltaTime, 0,0);
            return;
        }

        if (axisToMove ==  Axis.y)
        {
            transform.Translate(0, inputForce * moveForce * Time.deltaTime,0);
            return;
        }
    }
}