using UnityEngine;
using System.Collections;

public class IsBuy : MonoBehaviour 
{
	public BoxCollider2D[] box;
	public GameObject botao;
	// Use this for initialization
	void Start ()
	{
		if(PlayerPrefs.GetInt("isBUY") == 1)
		{
			Destroy(botao);
			Destroy(gameObject);
		}
		else
		{
			for(int i = 0; i < box.Length; i++)
			{
				box[i].enabled = false;
			}
		}
	}

	public void Button()
	{
		PlayerPrefs.SetInt("isBUY", 1);
		for(int i = 0; i < box.Length; i++)
		{
			box[i].enabled = true;
		}
		Destroy(botao);
	}
}
