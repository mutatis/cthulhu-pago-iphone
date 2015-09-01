using UnityEngine;
using System.Collections;

public class Special : MonoBehaviour {
	
	TextMesh text;
	int gh;
	char let;
	
	string[] texts = new string[] { "Our Families (feat. Danilo Curvo)", "Sonia", "Lu Valente", "Carolina Garrido", "Unity"};
	
	
	
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