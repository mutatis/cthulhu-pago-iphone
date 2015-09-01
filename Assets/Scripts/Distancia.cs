using UnityEngine;
using System.Collections;

public class Distancia : MonoBehaviour 
{
	float x;
	float posX;
	public int type;
	public GameObject life;
	public int ia;
	float conta;

	// Use this for initialization
	void Start () 
	{
		if(ia == 1)
		{
			life.SetActive(true);
		}
		posX = PlayerPrefs.GetFloat("percorreuS");
		if(posX <= 0)
		{
			posX = 1;
		}
		Debug.Log(posX);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(posX > 10)
		{
			conta = posX + PlayerStatus.playerStatus.transform.position.x;
		}
		else
		{
			conta = PlayerStatus.playerStatus.transform.position.x;
		}
		if(Time.timeScale != 0)
			x += 8.4f;

		if(type == 0)
			GetComponent<TextMesh>().text = (conta.ToString("f1"));

		if(type == 1)
			GetComponent<TextMesh>().text = ("" + x.ToString("f1"));
	}

	public void Apareca()
	{
		gameObject.SetActive(true);
	}
	public void Suma()
	{
		gameObject.SetActive(false);
	}
}
