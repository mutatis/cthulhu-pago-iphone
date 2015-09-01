using UnityEngine;
using System.Collections;

public class FELIPETEXT : MonoBehaviour {
	
	TextMesh text;
	int gh;
	char let;
	
	string[] texts = new string[] { "F", "E", "L", "I", "P", "E", "C", "U", "R", "V", "O"};
	
	
	
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