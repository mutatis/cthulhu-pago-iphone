using UnityEngine;
using System.Collections;

public class conte : MonoBehaviour {
	public float limit = 1000;//limit of new york scene
	public float onLvlUp = 1000;
	public bool haveItems;
	private int callNumber = 0;
	public ArrayList level = new ArrayList();
	public GameObject[] loading;
	public GameObject pause;
	public GameObject coins;
	public GameObject distancia;
	public GameObject life;
	public GameObject block;
	public GameObject music;
	int i;
	int x;
	int y;
	string fase;
	public Vector3 passo;

	// Use this for initialization
	void Start () 
	{
		GameManager.gameManager.to.Add(passo);
		level.Add("Ocean");
		if (PlayerPrefs.GetInt("hasRio") == 1)
		{
			i = level.Count + 1;
			level.Add("Rio de Janeiro");
		}
		if (PlayerPrefs.GetInt("hasMoon") == 1)
		{
			i = level.Count + 1;
			level.Add("Lua");
		}
		if (PlayerPrefs.GetInt("hasAfrica") == 1)
		{
			i = level.Count + 1;
			level.Add("Africa");
		}
		if (PlayerPrefs.GetInt("hasEgypt") == 1)
		{
			i = level.Count + 1;
			level.Add("Egypt");
		}
		if (PlayerPrefs.GetInt("hasChina") == 1)
		{
			i = level.Count + 1;
			level.Add("China");
		}
		if (PlayerPrefs.GetInt("hasIce") == 1)
		{
			i = level.Count + 1;
			level.Add("Ice");
		}
		if (PlayerPrefs.GetInt("hasNewYork") == 1)
		{
			i = level.Count + 1;
			level.Add("NewYork");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x >= limit)
		{
			x = Random.Range(0, level.Count);
			fase = level[x].ToString();
			if(fase == "Ocean")
			{
				y = 0;
			}
			else if(fase == "Rio de Janeiro")
			{
				y = 1;
			}
			else if(fase == "Lua")
			{
				y = 2;
			}
			else if(fase == "Africa")
			{
				y = 3;
			}
			else if(fase == "Egypt")
			{
				y = 4;
			}
			else if(fase == "China")
			{
				y = 5;
			}
			else if(fase == "Ice")
			{
				y = 6;
			}
			else if(fase == "NewYork")
			{
				y = 7;
			}
			StartCoroutine("OnMissionUpdate");
		}
	}

	IEnumerator OnMissionUpdate ()
	{
		NotificationCenter.DefaultCenter().PostNotification(this, "QuitScene");
		GameManager.gameManager.lvlUpCallsInTheLastMission = callNumber;
		PlayerPrefs.SetFloat("sLives", PlayerStatus.playerStatus.lives);
		PlayerPrefs.SetInt("Passo", 1);
		block.SetActive(false);
		PlayerPrefs.SetInt("timeS", 1);
		yield return new WaitForSeconds(8);
		pause.SetActive(false);
		coins.SetActive(false);
		loading[y].SetActive(false);
		distancia.SetActive(false);
		life.SetActive(false);
		loading[y].SetActive(true);
		PlayerPrefs.SetInt("timeS", 1);
		Destroy(music.gameObject);
		Application.LoadLevel (level[x].ToString());
		PlayerPrefs.SetInt("timeS", 1);
		StopCoroutine("OnMissionUpdate");
	}
}