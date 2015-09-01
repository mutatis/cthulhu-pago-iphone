using UnityEngine;
using System.Collections;

public class MaoCthulhu : MonoBehaviour 
{

	public Rigidbody2D super;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(super.velocity.y < 0)
		{
			if(transform.eulerAngles.z >= -20)
			{
				transform.Rotate(0, 0, -2f);
			}
			else
			{
				transform.eulerAngles = new Vector3(0, 0, -87);
			}
		}
		else if(super.velocity.y > 0)
		{
			if(transform.eulerAngles.z <= 20)
			{
				transform.Rotate(0, 0, 0.5f);
			}
			else
			{
				transform.eulerAngles = new Vector3(0, 0, 19);
			}
		}
	}
}
