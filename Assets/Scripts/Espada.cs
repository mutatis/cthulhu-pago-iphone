using UnityEngine;
using System.Collections;

public class Espada : MonoBehaviour 
{
	public static Espada espada;
	Vector2 direction;
	Vector2 theScale;
	public bool muda;
	public Transform mudou;
	public Transform cthulhu;
	public Transform papai;
	public GameObject martin;
	public int mm;
	public AudioSource espadag;
	public AudioClip dead;
	public GameObject[] desativar;

	void Awake()
	{
		espada = this;
	}

	// Use this for initialization
	void Start ()
	{
		mm = 1;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		for(int i = 0; i < desativar.Length; i++)
		{
			Destroy(desativar[i].gameObject);
		}
		//		transform.position = new Vector3 (PlayerStatus.playerStatus.transform.position.x + 100, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(muda == false)
		{
			direction = (Vector2)(PlayerStatus.playerStatus.transform.position - transform.position);
			direction.Normalize();
			transform.Translate (direction/2);
		}
		else
		{
			direction = (Vector2)(mudou.transform.position - transform.position);
			direction.Normalize();
			transform.Translate (direction * 3f);
			cthulhu.position = transform.position;
			papai.position = transform.position;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(dead, transform.position, 1f);
			espadag.Pause();
			FollowTarget.espada.segui = true;
			muda = true;
			PlayerStatus.playerStatus.StartCoroutine("Dying");
			martin.SetActive(true);
			//PlayerStatus.playerStatus.lives = 0;
		}
	}
}
