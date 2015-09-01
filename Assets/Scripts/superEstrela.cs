using UnityEngine;
using System.Collections;

public class superEstrela : MonoBehaviour 
{

	public Animator estrela;

	public void Anim()
	{
		estrela.enabled = false;
		transform.localScale = new Vector3(1.821959f, 1.821959f, 1.821959f);
	}
}
