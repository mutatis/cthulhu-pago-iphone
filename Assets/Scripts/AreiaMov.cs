using UnityEngine;
using System.Collections;

public class AreiaMov : MonoBehaviour 
{
	public float movX;
	public bool mov;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(mov == false)
		{
			transform.Translate (movX, 0, 0);
		}
	}
	public void DMov()
	{
		mov = true;
	}

	public void Mov()
	{
		mov = false;
	}
}
