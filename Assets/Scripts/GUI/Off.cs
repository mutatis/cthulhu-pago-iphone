using UnityEngine;
using System.Collections;

public class Off : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Desliga");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Desliga()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
