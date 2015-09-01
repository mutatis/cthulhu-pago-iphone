using UnityEngine;
using System.Collections;

public class ParticleBlack : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		if(Application.loadedLevelName == "Africa")
		{
			renderer.material.SetColor("_EmisColor", Color.black);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Application.loadedLevelName == "Africa")
		{
			renderer.material.SetColor("_EmisColor", Color.black);
		}
	}
}
