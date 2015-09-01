using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecttransformMM : MonoBehaviour {

	Transform rect;
	public Transform ok;

	// Use this for initialization
	void Start () 
	{
		rect = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rect.position = new Vector2(rect.position.x, ok.position.y);
	}
}
