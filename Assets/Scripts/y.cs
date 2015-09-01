using UnityEngine;
using System.Collections;

public class y : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Pan");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	IEnumerator Pan ()
	{
		yield return new WaitForSeconds(60);
			renderer.enabled = true;
	}
}
