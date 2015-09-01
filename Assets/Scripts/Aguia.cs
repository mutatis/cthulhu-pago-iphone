using UnityEngine;
using System.Collections;

public class Aguia : MonoBehaviour 
{
	Vector2 direction;
	Vector2 theScale;
	bool muda;
	public Transform mudou;
	AudioSource fx;

	// Use this for initialization
	void Start ()
	{
		fx = GetComponent<AudioSource> ();
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
//		transform.position = new Vector3 (PlayerStatus.playerStatus.transform.position.x + 100, transform.position.y, transform.position.z);
		StartCoroutine("Go");
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds (0.5f);
		fx.Play ();
	}

	// Update is called once per frame
	void Update () 
	{
		if(muda == false)
		{
			direction = (Vector2)(PlayerStatus.playerStatus.transform.position - transform.position);
			direction.Normalize();
			transform.Translate (direction * 2);
		}
		else
		{
			direction = (Vector2)(mudou.transform.position - transform.position);
			direction.Normalize();
			transform.Translate (direction * 2.5f);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			muda = true;
			PlayerStatus.playerStatus.StartCoroutine("Dying");
			PlayerStatus.playerStatus.lives = 0;
		}
	}
}
