using UnityEngine;
using System.Collections;

public class controlemanager : MonoBehaviour
{
	public UserControl indi;
	public GameObject[] codigos;
	public bool link;
	bool v = true;
	public GameObject[] cthulhu;
	public GameObject[] pika;
	public IABuyDagon ii;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(PlayerPrefs.GetString("Controle") == "babaupdownbaleftrightbastart")
		{
			Debug.Log("tartarugas");
		}
		else if(PlayerPrefs.GetString("Controle") == "abacabb")
		{
			codigos[0].SetActive(true);
			Debug.Log("mortal");
		}
		else if(PlayerPrefs.GetString("Controle") == "updownleftrightastart")
		{
			Debug.Log("sonic");
		}
		else if(PlayerPrefs.GetString("Controle") == "abdown")
		{
			for(int i = 0; i < cthulhu.Length; i++)
			{
				cthulhu[i].SetActive(false);
			}
			for(int i = 0; i < pika.Length; i++)
			{
				pika[i].SetActive(true);
			}
			ii.ok = true;
		}
		else if(PlayerPrefs.GetString("Controle") == "aarightac")
		{
			codigos[1].SetActive(true);
		}
		else if(PlayerPrefs.GetString("Controle") == "upupdowndownleftrightleftrightba")
		{
			codigos[3].SetActive(true);
			Debug.Log("konami");
		}
		else if(PlayerPrefs.GetString("Controle") == "startupa")
		{
			codigos[2].SetActive(true);
			codigos[4].SetActive(true);
			codigos[5].SetActive(false);
			codigos[6].SetActive(true);
			indi.indi = 1;
			Debug.Log("zelda");
		}
		
	}
}
