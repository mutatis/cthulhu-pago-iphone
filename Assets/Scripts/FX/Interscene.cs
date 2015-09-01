using UnityEngine;
using System.Collections;

public class Interscene : MonoBehaviour
{
    public  Sprite[] LoadingScreens; 

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

	}
	
	// Update is called once per frame
	public void TransitionIn ()
    {
        spriteRenderer.sprite = LoadingScreens[Application.loadedLevel];
        spriteRenderer.enabled = true;
	}

    public void TransitionOut ()
    {
        spriteRenderer.enabled = false;
    }
}
