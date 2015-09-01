using UnityEngine;
using System.Collections;

public class Chao : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		if(Application.loadedLevelName == "Africa")
		{
			transform.renderer.material.color = Color.black;
		}
	}
	

}
