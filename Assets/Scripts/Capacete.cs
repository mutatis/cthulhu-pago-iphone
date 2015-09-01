using UnityEngine;
using System.Collections;

public class Capacete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName != "Ocean")
		{
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
