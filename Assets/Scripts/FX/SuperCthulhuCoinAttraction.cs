using UnityEngine;
using System.Collections;

public class SuperCthulhuCoinAttraction : MonoBehaviour
{
    bool isAtracting = false;
    IEnumerator OnCollisionEnter2D (Collision2D collision2D)
    {
        isAtracting = false;
        yield return new WaitForSeconds (1);
        isAtracting = true;
    }

    void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (!isAtracting)
            return;
        if (collider2D.CompareTag("Coin"))
            collider2D.gameObject.AddComponent<ChasePlayer>();
    }
}
