using UnityEngine;
using System.Collections;

public class oceanpar : MonoBehaviour 
{
	public Transform cthulhu;


	void Start()
	{
		transform.position = cthulhu.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(-0.1f, 0, 0);
	}
}
