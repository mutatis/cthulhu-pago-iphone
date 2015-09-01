using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageD : UI_PopOnEventBase
{

	Image imageD;

	public override void OnDead ()
	{
		imageD.enabled = true;
	}

	// Use this for initialization
	void Start () 
	{
		imageD = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
