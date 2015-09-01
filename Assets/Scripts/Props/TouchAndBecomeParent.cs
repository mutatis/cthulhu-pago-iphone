using UnityEngine;
using System.Collections;

public class TouchAndBecomeParent : MonoBehaviour
{

	// Use this for initialization
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
            return;
        if (PlayerStatus.playerStatus.lives <= 0)
            collision.transform.root.parent = transform;
	}
	
	// Update is called once per frame
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
            return;
        if (PlayerStatus.playerStatus.lives <= 0)
            collider.transform.root.parent = transform;

	}
}
