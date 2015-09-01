using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextDigitacao : MonoBehaviour
{
	Text text;
	public string[] ola;
	public int oi;
	int i;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text>();
		text.text = "";
		Time.timeScale = 1;
		i = 0;
		StartCoroutine("Digita");
		//ola = text.text;
	}

	void Update()
	{

	}

	public void Prximo()
	{
		text.text = "";
		oi = 0;
		i ++;
		StartCoroutine("Digita");
	}
	public void Anterior()
	{
		text.text = "";
		oi = 0;
		i --;
		StartCoroutine("Digita");
	}

	IEnumerator Digita()
	{
		text.text = "";
		foreach(char letter in ola[i].ToCharArray())
		{
			oi++;
			if(i == 7 && oi == 45)
			{
				text.text = text.text + "\n";
			}
			else if(i == 0 && oi == 29)
			{
				text.text = text.text + "\n";
			}
			else if(i == 1 && oi == 26)
			{
				text.text = text.text + "\n";
			}
			else if(i == 2 && oi == 41)
			{
				text.text = text.text + "\n";
			}
			else if(i == 3 && oi == 35)
			{
				text.text = text.text + "\n";
			}
			else if(i == 4 && oi == 36)
			{
				text.text = text.text + "\n";
			}
			else if(i == 5 && oi == 43)
			{
				text.text = text.text + "\n";
			}
			else if(i == 6 && oi == 36)
			{
				text.text = text.text + "\n";
			}
			text.text += letter;
			yield return new WaitForSeconds(0.0002f);
		}
		StopCoroutine("Digita");
	}
}
