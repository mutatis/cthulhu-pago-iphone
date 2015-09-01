using UnityEngine;
using System.Collections;

public class testTwiiter : MonoBehaviour 
{

	public string text;
	public string url;
	public string related;
	string lang="en";

	const string Address = "http://twitter.com/intent/tweet";
	
	public void Share()
	{
		Application.OpenURL(Address +
		                    "?text=" + WWW.EscapeURL(text) +
		                    "&amp;url=" + WWW.EscapeURL(url) +
		                    "&amp;related=" + WWW.EscapeURL(related) +
		                    "&amp;lang=" + WWW.EscapeURL(lang));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
