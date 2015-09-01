using UnityEngine;
using System.Collections;

public class UI_Glass : UI_PopOnEventBase
{
    SpriteRenderer spriteRenderer;
    public override void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.material.color;
        originalColor.a = 0f;
        spriteRenderer.material.color = originalColor;
    }

    public override void OnDead ()
	{
		originalColor.a = 0.8f;
        spriteRenderer.material.color = originalColor;
	}

    public override void OnPause ()
    {
        originalColor.a = 0.8f;
        spriteRenderer.material.color = originalColor;
    }

    public override void OnResume ()
    {
        originalColor.a = 0f;
        spriteRenderer.material.color = originalColor;
    }
}