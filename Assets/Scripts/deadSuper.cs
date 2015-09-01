using UnityEngine;
using System.Collections;

public class deadSuper : MonoBehaviour 
{
	public GameObject super;
	public GameObject dead;
	public static deadSuper deadCthulhu;

	public GameObject[] alert;

	void Awake()
	{
		deadCthulhu = this;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void Morreu()
	{
		if(PlayerStatus.playerStatus.lives == 0)
		{
			super.SetActive(false);
			dead.SetActive(true);
			StartCoroutine("Dead");
			for(int i = 0; i < alert.Length; i++)
			{
				alert[i].SetActive(false);
			}
		}
	}

	IEnumerator Dead()
	{
		yield return new WaitForSeconds(3);
		NotificationCenter.DefaultCenter().PostNotification(this, "OnDead");
	}
}
