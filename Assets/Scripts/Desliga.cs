using UnityEngine;
using System.Collections;

public class Desliga : MonoBehaviour 
{

	public GameObject[] off;
	public MeshRenderer[] morre;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			for(int i = 0; i < off.Length; i++)
			{
				off[i].SetActive(false);
			}
			for(int i = 0; i < morre.Length; i++)
			{
				morre[i].enabled = false;
			}
		}
	}
}
