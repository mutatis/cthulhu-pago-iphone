using UnityEngine;
using System.Collections;

public class GABRIELTEXT : MonoBehaviour {
	
	TextMesh text;
	int gh;
	char let;
	
	string[] texts = new string[] { "G", "A", "B", "R", "I", "E", "L", "A", "U", "G", "U", "S", "T", "O"};
	
	
	
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
