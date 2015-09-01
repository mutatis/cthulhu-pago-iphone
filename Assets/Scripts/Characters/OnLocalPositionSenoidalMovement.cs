using UnityEngine;
using System.Collections;

public class OnLocalPositionSenoidalMovement : MonoBehaviour
{

    public float amplitudeX = 0.1f;
    public float frequencyX = 0.8f;
    public float amplitudeY = 0.1f;
    public float frequencyY = 1;

    private Vector2 offset;
    private Vector3 initialLocalPosition;
	public int tipo;

    void Start ()
    {
        initialLocalPosition = transform.localPosition;
    }

    void Update ()
    {
		if(Time.timeScale > -1)
		{
			offset.x = amplitudeX * Mathf.Sin(frequencyX*Time.time);
			offset.y = amplitudeY * Mathf.Sin(frequencyY*Time.time);
		    transform.localPosition = new Vector2 (initialLocalPosition.x,initialLocalPosition.y)  + offset;
		}
    }
}
