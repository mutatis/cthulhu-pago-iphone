using UnityEngine;
using System.Collections;

public class PEDROTEXT : MonoBehaviour {
	
	TextMesh text;
	int gh;
	char let;
	
	string[] texts = new string[] { "P", "E", "D", "R", "O", "A", "L", "M", "E", "I", "D", "A"};
	
	
	
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