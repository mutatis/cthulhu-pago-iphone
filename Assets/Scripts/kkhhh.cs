using UnityEngine;
using System.Collections;

public class kkhhh : MonoBehaviour {
	public float amplitudeX = 0.1f;
	public float frequencyX = 0.8f;
	public float amplitudeY = 0.1f;
	public float frequencyY = 1;

	private Vector2 offset;
	private Vector3 initialLocalPosition;
	public int tipo;
	// Use this for initialization
	void Start () {
		initialLocalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		offset.x = amplitudeX * Mathf.Sin(frequencyX);
		offset.y = amplitudeY * Mathf.Sin(frequencyY);
		transform.localPosition = new Vector2 (initialLocalPosition.x,initialLocalPosition.y)  + offset;
	}
}
