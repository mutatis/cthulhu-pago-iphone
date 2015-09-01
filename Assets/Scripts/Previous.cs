using UnityEngine;
using System.Collections;

public class Previous : MonoBehaviour 
{
	public Previous instance;
	public bool previous;

	void Awake()
	{
		instance = this;
	}

	public void NextGo()
	{
		previous = true;
	}

	public void PreviousGo()
	{
		previous =false;
	}
}