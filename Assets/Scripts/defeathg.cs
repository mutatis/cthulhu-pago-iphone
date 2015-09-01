using UnityEngine;
using System.Collections;

public class defeathg : MonoBehaviour 
{

	public GameObject[] lls;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");	
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds(5);
		lls[0].SetActive(true);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
