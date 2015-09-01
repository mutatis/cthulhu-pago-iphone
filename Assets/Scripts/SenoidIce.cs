using UnityEngine;
using System.Collections;

public class SenoidIce : MonoBehaviour 
{
	int velY;
	float vel;
	float tempo;
	bool mude;

	// Use this for initialization
	void Start () 
	{
		velY = Random.Range(1, 5);
		if(velY == 5)
		{
			tempo = 1;
			vel = 0.05f;
		}
		else if(velY == 4)
		{
			tempo = 1.5f;
			vel = 0.04f;
		}
		else if(velY == 3)
		{
			tempo = 2;
			vel = 0.03f;
		}
		else if(velY == 2)
		{
			tempo = 3;
			vel = 0.02f;
		}
		else if(velY == 1)
		{
			tempo = 5;
			vel = 0.01f;
		}
		StartCoroutine("Muda");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(velY + "oo" + tempo);
		transform.Translate(0, vel, 0);

		if(mude == true)
		{
			vel *= -1;
			mude = false;
			StartCoroutine("Muda");
		}
	}

	IEnumerator Muda()
	{
		yield return new WaitForSeconds(tempo);
		mude = true;
	}
}
