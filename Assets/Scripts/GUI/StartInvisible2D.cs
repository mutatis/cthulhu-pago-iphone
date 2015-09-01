using UnityEngine;
using System.Collections;

public class StartInvisible2D : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
        SpriteRenderer spriteRenderer;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.renderer.material.color = new Color (0,0,0,0);
    }

}
