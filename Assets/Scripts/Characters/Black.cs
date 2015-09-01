using UnityEngine;
using System.Collections;

public class Black : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GetComponent<SpriteRenderer>().color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<SpriteRenderer>().color = Color.black;
		transform.renderer.material.color = Color.black;
	}
}
