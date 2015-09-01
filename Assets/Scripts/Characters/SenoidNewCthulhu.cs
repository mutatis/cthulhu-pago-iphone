using UnityEngine;
using System.Collections;

public class SenoidNewCthulhu : MonoBehaviour
{
	public float senoid;
	float temp;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine("Senoid");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, senoid, 0);
	}

	IEnumerator Senoid()
	{
		yield return new WaitForSeconds(0.3f);
		temp = senoid;
		senoid = 0;
		yield return new WaitForSeconds(0.3f);
		senoid = temp;
		StartCoroutine("Senoid");
	}
}
