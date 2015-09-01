using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public GameObject distancia;
	public GameObject vida;
	public GameObject play;
	public GameObject shop;
	public GameObject creditos;
	public GameObject historia;
	public GameObject titulo;
	public GameObject pause;
	public GameObject painel;
	public GameObject provocacao1;
	bool sumiu;
	int time;

	void Awake()
	{
		time = PlayerPrefs.GetInt("timeS");
		Time.timeScale = time;
	}

	// Use this for initialization
	void Start () 
	{
		time = PlayerPrefs.GetInt("timeS");
		Time.timeScale = time;
		if(Time.timeScale == 1)
		{
			provocacao1.SetActive(true);
			painel.SetActive(false);
			play.SetActive(false);
			shop.SetActive(false);
			creditos.SetActive(false);
			historia.SetActive(false);
			titulo.SetActive(false);
		}
		else
		{
			painel.SetActive(true);
			play.SetActive(true);
			shop.SetActive(true);
			creditos.SetActive(true);
			historia.SetActive(true);
			titulo.SetActive(true);
		}
		sumiu = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(sumiu = true && Time.timeScale == 1)
		{
			painel.SetActive(false);
			play.SetActive(false);
			shop.SetActive(false);
			creditos.SetActive(false);
			historia.SetActive(false);
			titulo.SetActive(false);
			distancia.SetActive(true);
			vida.SetActive(true);
			pause.SetActive(true);
			sumiu = false;
		}
	}
}
