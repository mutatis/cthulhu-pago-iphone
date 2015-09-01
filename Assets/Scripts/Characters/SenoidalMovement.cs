using UnityEngine;
using System.Collections;

public class SenoidalMovement : MonoBehaviour
{

    public float amplitudeX = 1;
    public float frequencyX = 1;
    public float amplitudeY = 1;
    public float frequencyY = 1;

    private Vector2 offset;
    private Vector2 initialLocalPosition;

    void Start ()
    {
        initialLocalPosition = transform.localPosition;
    }

    void FixedUpdate ()
    {
		offset.x = amplitudeX * Mathf.Sin(frequencyX*Time.time);
		offset.y = amplitudeY * Mathf.Sin(frequencyY*Time.time);

		rigidbody2D.velocity = offset;
        transform.localPosition = initialLocalPosition + offset;
    }
}
