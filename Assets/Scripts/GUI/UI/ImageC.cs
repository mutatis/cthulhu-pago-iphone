using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageC : UI_PopOnEventBase 
{

	Image imageC;
	
	public override void OnDead ()
	{
		imageC.enabled = true;
	}
	
	// Use this for initialization
	void Start () 
	{
		imageC = GetComponent<Image>();
	}
}
