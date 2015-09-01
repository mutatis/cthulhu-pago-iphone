using UnityEngine;
using System.Collections;

public class Painel_open : MonoBehaviour 
{
	public GameObject globe;
	public GameObject panel;
	public GameObject text;

	// Update is called once per frame
	void Update () 
	{
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			text.SetActive(true);
			StartCoroutine("Dead");
		}
	}

	IEnumerator Dead()
	{
		yield return new WaitForSeconds(2.7f);
		panel.SetActive(true);
		globe.SetActive(true);
	}
}
