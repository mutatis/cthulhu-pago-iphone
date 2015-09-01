using UnityEngine;
using System.Collections;

public class piramide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
