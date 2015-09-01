using UnityEngine;
using System.Collections;

public class codi : MonoBehaviour 
{

	public Vector3 to;
	public Vector3 to2;
	int x = 1;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
	}

	IEnumerator Go()
	{
		System.DateTime timeToShowNextElement = System.DateTime.Now.AddSeconds(20);
		while (System.DateTime.Now < timeToShowNextElement)
		{
			yield return null;
		}
		if(x == 1)
		{
			iTween.RotateTo (gameObject, iTween.Hash("rotation", to, "speed", 12,"easetype", "Linear", "ignoretimescale",true));
			x = 2;
		}
		else if(x == 2)
		{
			iTween.RotateTo (gameObject, iTween.Hash("rotation", to2, "speed", 12,"easetype", "Linear", "onupdate", "SetMarkers", "oncomplete", "SetTarget", "ignoretimescale",true));
			x = 1;
		}
		StartCoroutine("Go");
	}
}
