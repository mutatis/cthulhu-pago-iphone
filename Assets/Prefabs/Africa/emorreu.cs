using UnityEngine;
using System.Collections;

public class emorreu : UI_PopOnEventBase 
{
	public GameObject sol;
	public GameObject cthulo;
	public GameObject arvores;
	public GameObject folhas;
	public GameObject distancia;
	public GameObject pontos;
	public GameObject chao;
	// Use this for initialization
	public override void Start ()
	{
		
	}
	
	public override void OnDead ()
	{
		sol.SetActive(false);
		cthulo.SetActive(false);
		arvores.SetActive(false);
		folhas.SetActive(false);
		distancia.SetActive(false);
		pontos.SetActive(false);
		chao.SetActive(false);
	}
	
	public override void OnPause ()
	{
		//transform.position = target.position + offset;
	}
	
	public override void OnResume ()
	{
	}
}
