using UnityEngine;
using System.Collections;

public class Disable : MonoBehaviour
{
	public iTween itwen;

	void Awake()
	{
		NotificationCenter notificationCenter = NotificationCenter.DefaultCenter();
		notificationCenter.AddObserver(this, "OnDead");
	}

	// Use this for initialization
	void Start () 
	{
		itwen = GetComponent<iTween>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			itwen = GetComponent<iTween>();
			itwen.enabled = false;
		}
	}

	void OnDead ()
	{
		//itwen = GetComponent<iTween>();
		if(!itwen)
			itwen.enabled = false;
	}
}
