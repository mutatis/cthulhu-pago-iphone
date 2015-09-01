using UnityEngine;
using System.Collections;

public class Shopping : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Shop()
	{
		Application.LoadLevel("CarSh");
	}

	public void Play()
	{
		gameObject.SetActive(false);
	}
}
