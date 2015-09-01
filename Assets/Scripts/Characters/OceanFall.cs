using UnityEngine;
using System.Collections;

public class OceanFall : MonoBehaviour 
{
	public Transform cthulhu;
	public Transform dagon;
	public Jump2D grounded;
	public Jump2D ground;
	public ParticleSystem part;
	public int type;
	bool play = true;
	bool posY;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetString("Dagon") != "Dagon")
		{
			posY = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(posY && type == 0)
		{
			if(grounded.grounded == false)
			{
				transform.position = transform.position;
				play = true;
				part.Stop();
			}
			else
			{
				transform.position = new Vector3(cthulhu.position.x, transform.position.y, cthulhu.position.z);
				if(play)
				{
					part.Play(true);
					StartCoroutine("Stop");
				}
			}
		}
		else if(type == 2 && posY) 
		{
			if(grounded.grounded == false)
			{
				transform.position = transform.position;
				play = true;
				part.Stop();
			}
			else
			{
				transform.position = new Vector3(cthulhu.position.x, transform.position.y, cthulhu.position.z);
				if(play)
				{
					part.Play(true);
					StartCoroutine("Stop");
				}
			}
		}
		else
		{
			if(ground.grounded == false)
			{
				transform.position = transform.position;
				play = true;
				part.Stop();
			}
			else
			{
				transform.position = new Vector3(dagon.position.x -2, transform.position.y, dagon.position.z);
				if(play)
				{
					part.Play(true);
					StartCoroutine("Stop");
				}
			}
		}

		if(type == 1)
		{
			if(ground.grounded == false)
			{
				transform.position = transform.position;
				play = true;
				part.Stop();
			}
			else
			{
				transform.position = new Vector3(dagon.position.x, transform.position.y, dagon.position.z);
				if(play)
				{
					part.Play(true);
					StartCoroutine("Stop");
				}
			}
		}
	}

	IEnumerator Stop()
	{
		yield return new WaitForSeconds(0.5f);
		play = false;
	}
}
