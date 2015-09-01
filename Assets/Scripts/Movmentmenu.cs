using UnityEngine;
using System.Collections;

public class Movmentmenu : MonoBehaviour
{
	
	public Transform[] button;
	public Transform[] min;
	public Transform[] max;
	public GameObject[] botao;
	int x = 1;
	int y;
	int z;
	bool ok;
	public GameObject dificuldade;
	public GameObject controle;

	// Use this for initialization
	void Start () 
	{		
		controle.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ok)
		{
			if(button[0].position.y > max[0].position.y - 5)
			{
				if(z >= 3)
					button[0].Translate(0, -20, 0);
			}
			if(button[1].position.y > max[1].position.y)
			{
				if(z >= 2)
					button[1].Translate(0, -20, 0);
			}
			if(button[2].position.y > max[2].position.y - 5)
			{
				if(z >= 1)
					button[2].Translate(0, -20, 0);
			}
			if(button[3].position.y > max[3].position.y)
			{
				if(z >= 0)
				{
					button[3].Translate(0, -20, 0);
				}
			}
			if(button[4].position.y < max[4].position.y)
			{
				if(z >= 4)
				{
					button[4].Translate(0, 20, 0);
				}
			}
		}
		if(z >= 7)
		{
			PlayerPrefs.SetInt("dificuldade", 0);
			PlayerPrefs.SetInt("timeS", 1);
			Time.timeScale = 1F;
			dificuldade.SetActive(false);
		}
	}

	public void Ok()
	{
		StartCoroutine("Cont");
		ok = true;
	}

	IEnumerator Cont()
	{
		System.DateTime timeToShowNextElement = System.DateTime.Now.AddSeconds(0.1f);
		while (System.DateTime.Now < timeToShowNextElement)
		{
			yield return null;
		}
		if(y >= 5)
		{
			x++;
		}
		z++;
		StartCoroutine("Cont");
	}
}
