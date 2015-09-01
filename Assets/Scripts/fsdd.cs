using UnityEngine;
using System.Collections;

public class fsdd : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0)
		{
			obj.SetActive(true);
		}
	}
}
