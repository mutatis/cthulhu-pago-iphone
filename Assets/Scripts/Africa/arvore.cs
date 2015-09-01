	using UnityEngine;
using System.Collections;

public class arvore : MonoBehaviour 
{
	public Transform cthulo;
	public int type;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1 && type == 0)
			transform.position = new Vector3(cthulo.position.x+20, 5.0754f, transform.position.z);

		else if(Time.timeScale == 1 && type == 1)
			transform.position = new Vector3(cthulo.position.x+20, 0, transform.position.z);

		else if(Time.timeScale == 1 && type == 2)
			transform.position = new Vector3(cthulo.position.x+20, 6, transform.position.z);

		else if(Time.timeScale == 1 && type == 3)
			transform.position = new Vector3(cthulo.position.x+20, 3, transform.position.z);
		else if(Time.timeScale == 1 && type == 4)
			transform.position = new Vector3(cthulo.position.x+20, 10, transform.position.z);
	}
}
