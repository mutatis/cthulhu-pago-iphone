using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class UI_PopText : UI_PopOnEventBase
{

    public override void Start ()
	{
		originalColor = guiText.color;
        guiText.enabled = false;
	}

    public override void OnDead ()
	{
        guiText.enabled = true;
		originalColor.a = 1f;
		guiText.color = originalColor;
	}

    public override void OnPause ()
    {
        guiText.enabled = true;
        originalColor.a = 1f;
        guiText.color = originalColor;
    }

    public override void OnResume ()
    {
        originalColor.a = 0f;
        guiText.color = originalColor;
        guiText.enabled = false;
    }
}