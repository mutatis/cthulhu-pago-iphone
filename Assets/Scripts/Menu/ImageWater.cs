using UnityEngine;
using System.Collections;

public class ImageWater : MonoBehaviour
{

	float posX = 0.1f;
	float posY = 0.1f;
	bool mudou;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Muda");
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine("Muda");
		transform.Translate(posX, posY, 0);
			posX *= -1;
			posY *= -1;
			mudou = false;
			StartCoroutine("Muda");
	}

	IEnumerator Muda()
	{
		yield return new WaitForSeconds(2f);
		mudou = true;
	}
}
