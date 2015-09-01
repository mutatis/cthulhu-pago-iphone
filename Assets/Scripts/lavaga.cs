using UnityEngine;
using System.Collections;

public class lavaga :  MonoBehaviour
{
	public GameObject effect;
	public AudioClip sfx;
	public Animator anim;
	public BoxCollider2D box;

	void Start()
	{
		anim = GetComponent<Animator>();
		StartCoroutine("Go");
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds(3);
		anim.SetTrigger("Lava");
		box.enabled = true;
	}

	IEnumerator OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
			yield return 0;
			PoolManager.Pools ["fx"].Spawn(effect.transform, collider.transform.position, effect.transform.rotation);
			Camera.main.gameObject.GetComponent<FollowTarget>().offset.x = 0;
			collider.gameObject.GetComponent<RigidBody2DUnidirectional>().maxSpeed = 0f;
			collider.gameObject.SetActive(false);
			yield return new WaitForSeconds(3.5f);
			NotificationCenter.DefaultCenter().PostNotification(this, "OnDead");
			//PlayerStatus.playerStatus.DisableRenderers();
		}
	}
}