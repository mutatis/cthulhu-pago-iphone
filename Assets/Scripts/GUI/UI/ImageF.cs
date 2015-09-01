using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageF : UI_PopOnEventBase
{
	
	public GameObject[] fases;
	bool aparece;
	public Sprite[] sprites;
	public Image[] render;
	int muda = 0;
	public string nfases;
	int number;
	int temp = 50;
	int i = 1;
	string nn;
	string temps = "l";

	void Start()
	{
		GameManager.gameManager.fases = GameManager.gameManager.fases + nfases;
	}

	public override void OnDead ()
	{
		aparece = true;
		muda ++;
		Time.timeScale = 1;

		for(int i = 0; i < fases.Length; i++)
		{
			fases[i].SetActive(true);
		}
		StartCoroutine ("Go");
	}
	
	void Update()
	{
		if(aparece)
		{

			if(Input.GetMouseButtonDown(0))
			{
				/*for(int i = 0; i < fases.Length; i++)
				{
					fases[i].SetActive(true);
				}*/
			}
		}
	}	
	IEnumerator Go()
	{

		foreach(char letter in GameManager.gameManager.fases.ToCharArray())
		{

				Debug.Log (nn);
			nn = letter.ToString();
			if(nn != temps)
			{
				if(nn == "4")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[3];					
					i++;
				}
				if(nn == "1")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[0];
									
					i++;
				}
				if(nn == "5")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[4];

					i++;
				}
				if(nn == "2")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[1];
									
					i++;
				}
				if(nn == "3")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[2];
									
					i++;
				}
				if(nn == "6")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[5];
										
					i++;
				}
				if(nn == "7")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[6];

					i++;
				}
				if(nn == "8")
				{
					render[i].enabled = true;
					render[i].sprite = sprites[7];

					i++;
				}
				temps = nn;
			}
			else
			{
				yield return new WaitForSeconds(0.1f);
			}

				
			yield return new WaitForSeconds(1);
		}
	}
}