using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Dead : UI_PopOnEventBase 
{
	public GameObject retry;
	public GameObject menu;
	public GameObject estrela;
	public GameObject distancia;
	public GameObject coins;
	public GameObject panel;
	public Text text;
	public int compre;
	public GameObject hipnotco;
	public int aah;
	public GameObject hip;
	public GameObject[] desativa;
	public Text[] texto;
	public Image[] imagem;
	public Vector3 passo;

	void Start ()
	{
		compre = PlayerPrefs.GetInt("CORRE");
	}

	void Update()
	{

	}

	public void Sair()
	{
		retry.SetActive(true);
		menu.SetActive(true);
		hip.SetActive (false);
		distancia.SetActive(false);
		coins.SetActive(false);
		estrela.SetActive(true);
		panel.SetActive(true);
		GameManager.gameManager.ResetCoins();
	}
	
	public override void OnDead ()
	{		
		GameManager.gameManager.to.Add(passo);
		estrela.SetActive(true);
		PlayerPrefs.SetInt ("Espinhos", 0);
		text.enabled = false;
		if(compre >= 5 && PlayerPrefs.GetInt("BuyGame") != 1)
		{
			hip.SetActive(true);
			hipnotco.SetActive(true);
			PlayerPrefs.SetInt("CORRE", 0);
		}
		else
		{
			compre ++;
			retry.SetActive(true);
			menu.SetActive(true);
			PlayerPrefs.SetInt("CORRE", compre);
			distancia.SetActive(false);
			coins.SetActive(false);
			estrela.SetActive(true);
			panel.SetActive(true);
			GameManager.gameManager.ResetCoins();
		}
		for (int i = 0; i < desativa.Length; i++) 
		{
			desativa[i].SetActive(false);
		}
		for(int i = 0; i < texto.Length; i++)
		{
			texto[i].enabled = true;
		}
		for(int i = 0; i < imagem.Length; i++)
		{
			imagem[i].enabled = true;
		}
	}
	
	public override void OnPause ()
	{
		//transform.position = target.position + offset;
	}
	
	public override void OnResume ()
	{
	}
}
