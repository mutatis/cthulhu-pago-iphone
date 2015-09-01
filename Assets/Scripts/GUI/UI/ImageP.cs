using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageP : UI_PopOnEventBase 
{
	
	Image imageP;
	
	public override void OnDead ()
	{
		imageP.enabled = true;
	}
	
	// Use this for initialization
	void Start () 
	{
		imageP = GetComponent<Image>();
	}
}
