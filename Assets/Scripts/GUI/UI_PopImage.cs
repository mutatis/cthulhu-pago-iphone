using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUITexture))]
public class UI_PopImage : UI_PopOnEventBase
{
    protected bool isActive = false;
    public override void Start ()
	{
		originalColor = guiTexture.color;
        isActive = false;
	}

    public override void OnDead ()
	{
        isActive = true;

		originalColor.a = 1f;
		guiTexture.color = originalColor;
	}

    public override void OnPause ()
    {
        isActive = true;

        originalColor.a = 1f;
        guiTexture.color = originalColor;
    }

    public override void OnResume ()
    {
        isActive = false;
        originalColor.a = 0f;
        guiTexture.color = originalColor;
    }
}