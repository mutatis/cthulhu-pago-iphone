using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Text_UI : UI_PopOnEventBase 
{
	bool morre;
	bool dead;
	public Transform cthulo;
	public Transform dagon;
	float distancia;
	Text textDist;
	public UI_Dead aah;
	public AudioSource audio;
	public AudioSource audio1;
	int cont;

	public override void OnDead ()
	{
		morre = true;
		dead = true;
		textDist.enabled = true;
	}
	// Use this for initialization
	void Start () 
	{
		textDist = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(aah.aah >= 500 && aah.compre >= 5)
		{
			if(PlayerPrefs.GetString("Dagon") != "Dagon")
			{
				if(Input.GetMouseButtonDown(0) && morre)
				{
					if(cont == 0)
					{
						audio1.Play();
						cont ++;
					}
					audio.Stop();
					dead = false;
					distancia = cthulo.position.x;
				}
				if(dead)
				{
					if(distancia < cthulo.position.x)
					{
						distancia += 5;
						audio.Play();
					}
					else
					{
						distancia = cthulo.position.x;
						audio.Stop();
					}
				}
				textDist.text = "" + (int)(distancia + PlayerPrefs.GetFloat("percorreuS"));
			}
			else
			{
				if(Input.GetMouseButtonDown(0) && morre)
				{
					if(cont == 0)
					{
						audio1.Play();
						cont ++;
					}
					audio.Stop();
					dead = false;
					distancia = dagon.position.x;
				}
				if(dead)
				{
					if(distancia < dagon.position.x)
					{
						distancia += 5;
						audio.Play();
					}
					else
					{
						distancia = dagon.position.x;
						audio.Stop();
					}
				}
				textDist.text = "" + (int)(distancia + PlayerPrefs.GetFloat("percorreuS"));
			}
		}
		else
		{
			if(PlayerPrefs.GetString("Dagon") != "Dagon")
			{
				if(Input.GetMouseButtonDown(0) && morre)
				{
					if(cont == 0)
					{
						audio1.Play();
						cont ++;
					}
					audio.Stop();
					dead = false;
					distancia = cthulo.position.x;
				}
				if(dead)
				{
					if(distancia < cthulo.position.x)
					{
						audio.Play();
						distancia += 5;
					}
					else
					{
						distancia = cthulo.position.x;
						audio.Stop();
					}
				}
				textDist.text = "" + (int)(distancia + PlayerPrefs.GetFloat("percorreuS"));
			}
			else
			{
				if(Input.GetMouseButtonDown(0) && morre)
				{
					if(cont == 0)
					{
						audio1.Play();
						cont ++;
					}
					audio.Stop();
					dead = false;
					distancia = dagon.position.x;
				}
				if(dead)
				{
					if(distancia < dagon.position.x)
					{
						audio.Play();
						distancia += 5;
					}
					else
					{
						distancia = dagon.position.x;
						audio.Stop();
					}
				}
				textDist.text = "" + (int)(distancia + PlayerPrefs.GetFloat("percorreuS"));
			}
		}
	}
}
