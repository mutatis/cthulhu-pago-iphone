using UnityEngine;
using System.Collections;

public class DeadManagers : MonoBehaviour 
{
	public GameObject menuDead;
	public GameObject retry;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			menuDead.SetActive(true);
			retry.SetActive(true);
		}
	}
}
