using UnityEngine;
using System.Collections;

public class menuDesce : MonoBehaviour {

	bool desca;
	public Transform max;
	public Transform min;
	public Transform max2;
	public Transform min2;
	public GameObject target;
	public static menuDesce menu;
	public GameObject[] back;
	public Transform pig;
	public AudioClip[] botao;

	public Transform por3;
	float x;
	float x1;
	float x2;

	void Awake()
	{
		menu = this;
	}

	// Use this for initialization
	void Start () 
	{

		x2 = por3.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(desca == false)
		{
			if(transform.position.x < max.position.x)
			{
				transform.Translate(0.01f, 0, 0);
			}
			/*else if(transform.position.y > max.position.y + 5)
			{
				transform.Translate(0, -20, 0);
				dificuldade.Translate(0, -20, 0);
			}*/
			else
			{
				transform.position = new Vector2(max.position.x, transform.position.y);
				//dificul.SetActive(false);
			}
			if(pig.position.y > max2.position.y)
			{
				pig.Translate(0, -0.01f, 0);

				por3.Translate(0, -0.5f, 0);
			}
			else
			{
				pig.position = new Vector2(pig.position.x, max2.position.y);
				por3.position = new Vector2(por3.position.x, x2);
			}
		}
		else
		{
			if(transform.position.x > min.position.x)
			{
				transform.Translate(-0.01f, 0, 0);
			}
			else
			{
				transform.position = new Vector2( min.position.x, transform.position.y);
				Clico();
			}
			if(pig.position.y < min2.position.y)
			{
				pig.Translate(0, 0.01f, 0);

				por3.Translate(0, 0.5f, 0);
			}
			else
			{
				pig.position = new Vector2(pig.position.x, min2.position.y);

				por3.position = new Vector2(por3.position.x, 17.5f);
				Clico();
			}
		}
	}

	public void Desca()
	{
		AudioSource.PlayClipAtPoint(botao[0], transform.position, 1f);
		back[0].SetActive(true);
		back[1].SetActive(false);
		desca = true;
	}

	public void Desliga()
	{
		target.SetActive(false);
	}

	public void Sobe()
	{
		desca = false;
	}

	void Clico()
	{
		NotificationCenter.DefaultCenter().PostNotification(this,"DisplayOptions" , target);
	}
}