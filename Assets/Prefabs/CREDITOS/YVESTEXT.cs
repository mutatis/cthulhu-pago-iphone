using UnityEngine;
using System.Collections;

public class YVESTEXT : MonoBehaviour {
	
	TextMesh text;
	int gh;
	char let;
	
	string[] texts = new string[] { "Y", "V", "E", "S", "A", "L", "B", "U", "Q", "U", "E", "R", "Q", "U", "E"};
	
	
	
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