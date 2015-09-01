using UnityEngine;
using System.Collections;

public class UI_Resume : UI_PopImage
{
	public GameObject pause;
	public GameObject life;
	public GameObject distancia;
	public int ia;
	public GameObject cthulu;
	public GameObject menu;
	public PlayParticle play;
	SpriteRenderer backgrondDarkner;

	void Start()
	{
		backgrondDarkner = Camera.main.transform.FindChild("BackgroundDarkener").GetComponent<SpriteRenderer>();
		Time.timeScale = 0;
	}

    public void OnMouseUpAsButton()
    {
		distancia.SetActive(true);
		pause.SetActive(true);
		life.SetActive(true);
		backgrondDarkner.enabled = false;
		gameObject.SetActive(false);
		if(ia == 0)
		{
			play.pauso -= 1;
		}
		cthulu.SetActive(false);
		menu.SetActive(false);
		Time.timeScale = 1;
        NotificationCenter.DefaultCenter().PostNotification(this, "OnResume");
    }
}