using UnityEngine;
using System.Collections;

public class IABuyDagon : MonoBehaviour 
{
	public GameObject dagon;
	public GameObject cthulhu;
	public GameObject veado;
	public GameObject santaD;
	public GameObject santaC;
	public GameObject santaV;
	public Transform dagonT;
	public Transform cthulhuT;
	public Transform veadoT;
	int d;
	public GameObject repelente;
	public GameObject[] desativar;
	public bool ok;
	public static IABuyDagon buyDagon;
	public GameObject[] cthu;
	public GameObject ii;
	public bool aah;

	void Awake()
	{
		buyDagon = this;
	}

	// Use this for initialization
	void Start () 
	{
		if((PlayerPrefs.GetInt("repelenteN") >= 10 && PlayerPrefs.GetInt("BuyGame") != 1) || PlayerPrefs.GetInt("GOH") == 1)
		{
			PlayerPrefs.SetInt("Srepelente", 1);
			Instantiate(repelente);
			aah = false;
		}

		if(PlayerPrefs.GetString("Dagon") == "Dagon")
		{
			dagon.SetActive(true);
			santaD.SetActive(true);
			d = 1;
		}
		/*else if(PlayerPrefs.GetString("Dagon") == "Veado")
		{
			veado.SetActive(true);
			santaV.SetActive(true);
			d = 3;
		}*/
		else
		{
			cthulhu.SetActive(true);
			santaC.SetActive(true);
			d = 2;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = PlayerStatus.playerStatus.transform.position;
		if(PlayerPrefs.GetInt("repelenteN") >= 5 && PlayerPrefs.GetInt("BuyGame") != 1 && PlayerPrefs.GetInt("Srepelente") != 1)
		{
			if(aah == false)
			{
				ii.SetActive(true);
			}
			PlayerPrefs.SetInt("Srepelente", 1);
		}
		if(GameManager.gameManager.moeda >= 790 && PlayerPrefs.GetInt("GOH") == 0)
		{
			ii.SetActive(true);
			PlayerPrefs.SetInt("GOH", 1);
		}
		if(aah == true && PlayerStatus.playerStatus.lives > 0)
		{
			aah = false;
		}
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			for(int i = 0; i < desativar.Length; i++)
			{
				desativar[i].SetActive(false);
			}
		}
	}
}
