using UnityEngine;
using System.Collections;

public class LoadingSh : MonoBehaviour 
{
	public GameObject[] obj;

	// Use this for initialization
	void Start () 
	{
		obj[Random.Range(0, obj.Length)].SetActive(true);
		Application.LoadLevel("Shopping");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
