using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Provocacao : MonoBehaviour 
{
	public string[] provoca;
	Text text;
	int sorteio;
	bool dead;
	int cont;

	// Use this for initialization
	void Start () 
	{
		text = GetComponent<Text>();
		sorteio = Random.Range(0, provoca.Length);
		text.text = provoca[sorteio];
		StartCoroutine("Of");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerStatus.playerStatus.lives <= 0 && dead == false && cont == 0)
		{
			cont = 1;
			dead = true;
		}
		if(dead && cont == 1)
		{
			text = GetComponent<Text>();
			sorteio = Random.Range(0, provoca.Length);
			text.text = provoca[sorteio];
			StartCoroutine("Of");
			cont = 2;
		}
	}

	IEnumerator Of()
	{
		yield return new WaitForSeconds(2);
		gameObject.SetActive(false);
	}
}
