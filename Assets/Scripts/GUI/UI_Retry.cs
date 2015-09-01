using UnityEngine;
using System.Collections;

public class UI_Retry : UI_PopImage
{
	public string levelRetry;
	public GameObject loading;
	public GameObject loadingA;
	public GameObject globe;
	public GameObject coins;
	public GameObject pause;
	public GameObject distancia;
	public GameObject estrela;
	public GameObject canvas;
	int time = 1;
	int compre;
	int contPlay;
	int contRepele;

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
		GameManager.gameManager.ResetCoins();
		PlayerPrefs.SetInt ("Galinhas", 0);
		PlayerPrefs.SetInt("Passo", 0);
		for (int i = 0; i < MissionManager.mission.desativar.Length; i++)
		{
			MissionManager.mission.desativar[i].SetActive(false);
		}
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
		Time.timeScale = 1;
	}

	IEnumerator Va ()
	{
		estrela.SetActive(false);
		canvas.SetActive(false);
		loading.SetActive(true);
		loadingA.SetActive(true);
		globe.SetActive(false);
		coins.SetActive(false);
		pause.SetActive(false);
		distancia.SetActive(false);
		Time.timeScale = 1;
		AsyncOperation async = Application.LoadLevelAsync(levelRetry);
		yield return async;
	}
}