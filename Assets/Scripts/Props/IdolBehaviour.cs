using UnityEngine;
using System.Collections;

public class IdolBehaviour : MonoBehaviour
{
    public static int iDol;
    public AudioClip[] pickupClip;
    private bool taked = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" || taked)
            return;
		if (GameManager.gameManager.doubleCoin)
			GameManager.gameManager.AddCoin();
		GameManager.gameManager.AddCoin(10);
        GetComponent<OnLocalPositionSenoidalMovement>().enabled = false;
        iTweenEvent.GetEvent(gameObject, "Go").Play();
        // Play the collection sound.
        audio.PlayOneShot(pickupClip[Random.Range(0, pickupClip.Length)]);
        taked = true;
    }
}