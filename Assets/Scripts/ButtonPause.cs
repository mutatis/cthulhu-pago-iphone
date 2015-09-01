using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPause : UI_PopText 
{
	public bool pause;
	public GameObject resume;
	public GameObject cthulu;
	public GameObject menu;
	public static ButtonPause instance;
	public int ia;
	public int type;
	SpriteRenderer backgrondDarkner;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		backgrondDarkner = Camera.main.transform.FindChild("BackgroundDarkener").GetComponent<SpriteRenderer>();
		if(type == 0)
		{
			gameObject.SetActive(false);
		}
		resume.SetActive(false);
		menu.SetActive(false);
	}

	void Update()
	{
		/*if(Time.timeScale == 0)
		{
			gameObject.SetActive(true);
		}*/
		if(Application.isPlaying)
		{
		
		}
		else
		{
			menu.SetActive(true);
			Time.timeScale = 0;
			NotificationCenter.DefaultCenter().PostNotification(this, "OnPause");
			pause = true;
			backgrondDarkner.enabled = true;
			gameObject.SetActive(false);
			resume.SetActive(true);
			cthulu.SetActive(true);
			//StartCoroutine("Go");
		}
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			GetComponent<Button>().enabled = false;
			GetComponent<Image>().enabled = false;
			gameObject.SetActive(false);
		}
	}

	public void OnMouseDown()
	{
		Time.timeScale = 0;
		menu.SetActive(true);
		Time.timeScale = 0;
		NotificationCenter.DefaultCenter().PostNotification(this, "OnPause");
		pause = true;
		backgrondDarkner.enabled = true;
		gameObject.SetActive(false);
		resume.SetActive(true);
		cthulu.SetActive(true);
		//StartCoroutine("Go");
		Time.timeScale = 0;
	}

	public void Aparecer()
	{
		gameObject.SetActive(true);
	}
}