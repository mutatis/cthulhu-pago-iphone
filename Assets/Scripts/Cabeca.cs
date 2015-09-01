using UnityEngine;
using System.Collections;

public class Cabeca : MonoBehaviour 
{

	public int tempo;
	public float vel;
	bool mudou;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Muda");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, vel, 0);
		if(mudou)
		{
			vel *= -1;
			StartCoroutine("Muda");
			mudou = false;
		}
	}

	IEnumerator Muda()
	{
		yield return new WaitForSeconds(tempo);
		mudou = true;
	}
}
