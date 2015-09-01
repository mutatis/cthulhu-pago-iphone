using UnityEngine;
using System.Collections;

public class blashs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (guiTexture.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
			print ("This gui texture covers pixel 360, 450");
	}
}
