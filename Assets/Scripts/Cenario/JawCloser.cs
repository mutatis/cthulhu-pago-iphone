using UnityEngine;
using System.Collections;

public class JawCloser : MonoBehaviour
{
    public GameObject target;
	public AudioClip entrace;
	bool ok;

    void OnTriggerEnter2D (Collider2D collider)
    {
		if(ok == false)
		{
			AudioSource.PlayClipAtPoint (entrace, transform.position, 0.8f);
			ok = true;
		}
        iTweenEvent.GetEvent(target, "CloseJaw").Play();
    }
}
