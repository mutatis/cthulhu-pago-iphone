using UnityEngine;
using System.Collections;

public class testparalax : MonoBehaviour {

	public float speed = 0;
	float posx = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		posx += speed;
		if(posx > 1.0f)
		{
			posx -= 1.0f;
		}

		renderer.material.mainTextureOffset = new Vector2(posx, 0);
	}
}
