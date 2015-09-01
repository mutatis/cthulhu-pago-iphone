using UnityEngine;
using System.Collections;

public class SetSpriteColor : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
        Color newColor = Camera.main.backgroundColor;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;
        spriteRenderer.color = newColor;
	}
}
