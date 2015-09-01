using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TEXTREF : MonoBehaviour {

	TextMesh text;
	int gh;
	char let;

	string[] texts = new string[] { "P", "E", "D", "R", "O", "C", "A", "S", "T", "R", "O"};
	


	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
		gh = Random.Range(0, texts.Length);
		text.text = texts[gh];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
