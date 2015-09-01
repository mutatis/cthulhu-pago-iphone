using UnityEngine;
using System.Collections;

public class Easy : MonoBehaviour 
{

	public GameObject dificuldade;
	public GameObject provocacao;
	public GameObject bored;
	public GameObject grupo;
	int mov;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("BuyGame") == 1)
		{
			bored.SetActive(true);
			grupo.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*Debug.Log(mov);
		if(Time.timeScale == 0)
		{
			camera.Translate(mov, 0, 0);
			if(camera.position.x <= 13)
			{
				mov *= -1;
			}
			if(camera.position.x >= 1)
			{
				mov = 0;
			}
		}*/
	}

	public void EasySelect()
	{
		provocacao.SetActive(true);
		dificuldade.SetActive(false);
		PlayerPrefs.SetInt("dificuldade", 1);
	}
}
