using UnityEngine;
using System.Collections;

public class espinhos : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && PlayerPrefs.GetInt("Espinhos") == 0)
		{
			FollowTarget.espada.segui = true;
			PlayerStatus.playerStatus.StartCoroutine("Dying");
			PlayerStatus.playerStatus.lives = 0;
			PlayerPrefs.SetInt("Espinhos", 1);
		}
	}
}
