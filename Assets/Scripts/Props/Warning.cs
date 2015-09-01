using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;
    }
	// Update is called once per frame
	IEnumerator OnSpawn (int index)
	{
        spriteRenderer.sprite = sprites[index];
		InvokeRepeating("Blink", 0f, 0.5f);
		yield return new WaitForSeconds (0.5f);
		renderer.enabled = false;
		CancelInvoke();
	}

	void Blink ()
	{
		renderer.enabled = !renderer.enabled;
	}
}
