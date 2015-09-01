using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour
{
    public AudioClip pickupClip;		
    private Animator anim;					
    private bool landed;					

    virtual public void Awake()
    {
        anim = transform.root.GetComponent<Animator>();
    }

    virtual public void OnTrigger2DEnter(Collider2D other)
    {
        // If the player enters the trigger zone...
        if (other.tag == "Player")
        {
            // Play the collection sound.
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);

            gameObject.SetActive(false);
        }
        // Otherwise if the crate hits the ground...
        else if (other.gameObject.layer == LayerMask.NameToLayer("Ground") && !landed)
        {
            // ... set the Land animator trigger parameter.
            anim.SetTrigger("Land");
            transform.parent = null;
            landed = true;
        }
    }
}
