using UnityEngine;
using System.Collections;

public class UI_Home : UI_PopImage 
{
	public string level;
	public GameObject loading;
	public GameObject loadingA;
	public GameObject globe;
	public GameObject coins;
	public GameObject pause;
	public GameObject distancia;
	public GameObject pCthulo;
	public GameObject estrela;
	public GameObject canvas;
	int compre;
	int time = 0;
	int contRepele;
	int contPlay;

	void Start()
	{
		contRepele = PlayerPrefs.GetInt("repelente");
		contPlay = PlayerPrefs.GetInt("ContPlay");
	}

	void Update()
	{
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			gameObject.SetActive(true);
		}
	}

	public void OnMouseUpAsButton()
	{
		PlayerPrefs.SetString("Controle", "");
		if(GameManager.gameManager.gift == 1)
		{
			PlayerPrefs.SetInt("doubleCoin", 1);
			GameManager.gameManager.doubleCoin = true;
		}
		if(GameManager.gameManager.gift == 0)
		{
			PlayerPrefs.SetInt("hasContinue", 1);
			GameManager.gameManager.hasContinue = true;
		}
		if(GameManager.gameManager.gift != 1)
		{
			PlayerPrefs.SetInt("doubleCoin", 0);
			GameManager.gameManager.doubleCoin = false;
		}
		PlayerPrefs.SetInt("Passo", 0);
		if(PlayerPrefs.GetInt("BuyGame") == 0)
		{
			GameManager.gameManager.ResetCoins();
		}
		PlayerPrefs.SetFloat("percorreuS", 0);
		for(int i = 0; i < MissionManager.mission.desativar.Length; i++)
		{
			MissionManager.mission.desativar[i].SetActive(false);
		}
		PlayerPrefs.SetInt ("Galinhas", 0);
		contRepele ++;
		PlayerPrefs.SetInt("repelente", contRepele);
		contPlay ++;
		PlayerPrefs.SetInt("ContPlay", contPlay);
		if(contPlay >= 200 && PlayerPrefs.GetString("Dagon") != "Dagon")
		{
			PlayerPrefs.SetString("Dagon", "Veado");
		}
		compre = PlayerPrefs.GetInt("CORRE");
		compre ++;
		PlayerPrefs.SetInt("CORRE", compre);
		PlayerPrefs.SetInt("timeS", time);
		GameManager.gameManager.Remove();
		StartCoroutine("Va");
	}

	IEnumerator Va ()
	{
		Time.timeScale = 0;
		canvas.SetActive(false);
		estrela.SetActive(false);
		loading.SetActive(true);
		loadingA.SetActive(true);
		globe.SetActive(false);
		coins.SetActive(false);
		pause.SetActive(false);
		distancia.SetActive(false);
		pCthulo.SetActive(false);
		AsyncOperation async = Application.LoadLevelAsync(level);
		yield return async;
	}
}