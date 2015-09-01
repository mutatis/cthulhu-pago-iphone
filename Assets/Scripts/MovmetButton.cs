using UnityEngine;
using System.Collections;

public class MovmetButton : MonoBehaviour
{

	public Transform[] button;
	public Transform[] min;
	public Transform[] max;
	public GameObject[] botao;
	int x = 1;
	int y;
	int z;

	// Use this for initialization
	void Start () 
	{		
		StartCoroutine("Cont");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(button[0].position.y < max[0].position.y - 5)
		{
			if(z >= 4)
			button[0].Translate(0, 20, 0);
		}
		else
		{
			button[0].position = new Vector2(button[0].position.x, max[0].position.y);
		}
		if(button[1].position.y < max[1].position.y)
		{
			if(z >= 5)
			button[1].Translate(0, 20, 0);
		}
		else
		{
			button[1].position = new Vector2(button[1].position.x, max[1].position.y);
		}
		if(button[2].position.y < max[2].position.y - 5)
		{
			if(z >= 6)
			button[2].Translate(0, 20, 0);
		}
		else
		{
			button[2].position = new Vector2(button[2].position.x, max[2].position.y);
		}
		if(button[8].position.y < max[8].position.y)
		{
			if(z >= 7)
				button[8].Translate(0, 20, 0);
		}
		else
		{
			button[8].position = new Vector2(button[8].position.x, max[8].position.y);
		}
		if(button[3].position.y > max[3].position.y)
		{
			if(z >= 3)
			{
				button[3].Translate(0, -20, 0);
			}
		}
		else
		{
			y++;
			botao[3].SetActive(false);
		}
		if(button[4].position.y > max[4].position.y)
		{
			if(z >= 2)
			{
				button[4].Translate(0, -20, 0);
			}
		}
		else
		{
			y++;
			botao[1].SetActive(false);
		}
		if(button[5].position.y > max[5].position.y)
		{
			if(z >= 1)
			{
				button[5].Translate(0, -20, 0);
			}
		}
		else
		{
			y++;
			botao[2].SetActive(false);
		}
		if(button[6].position.y > max[6].position.y)
		{
			if(z >= 0)
			{
				button[6].Translate(0, -20, 0);
			}
		}
		else
		{
			y++;
			botao[6].SetActive(false);
		}
		if(button[7].position.y < max[7].position.y)
		{
			if(z >= 0)
			{
				button[7].Translate(0, 20, 0);
			}
		}
		else
		{
			y++;
			botao[5].SetActive(false);
		}
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
