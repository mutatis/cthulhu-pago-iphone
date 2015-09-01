using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	public bool next;
	public static Next instance;
	public int x = 1;
	
	void Awake()
	{
		instance = this;
	}

	public void NextGo()
	{
		x++;
	}
	
	public void PreviousGo()
	{
		x--;
	}
}
