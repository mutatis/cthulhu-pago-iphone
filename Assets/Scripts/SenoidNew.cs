using UnityEngine;
using System.Collections;

public class SenoidNew : MonoBehaviour {
	public Rigidbody2D c;

	// Use this for initialization
	void Start () {
		StartCoroutine("Jumpinho");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Jumpinho()
	{
		c.velocity = new Vector3(0, 10, 0);
		yield return new WaitForSeconds(0.8f);
		StartCoroutine("Jumpinho");
	}
}
