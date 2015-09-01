using UnityEngine;
using System.Collections;

public class RollingRock : MonoBehaviour
{
    void Update ()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z -5);
    }
	void OnCollisionEnter2D (Collision2D collision)
	{
		//NotificationCenter.DefaultCenter().PostNotification(this, "OnDead");
	}
}
