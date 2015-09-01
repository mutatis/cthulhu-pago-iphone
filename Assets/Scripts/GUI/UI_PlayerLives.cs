using UnityEngine;
using System.Collections;


public class UI_PlayerLives : MonoBehaviour
{
	public Texture2D livesIcon;
	public GameObject Creditos;
	public int ds;

	void Start()
	{
		if(ds == 1)
		{
			gameObject.SetActive(true);
		}
	}

	// Update is called once per frame
	void OnGUI ()
	{
		GUILayout.BeginHorizontal();
		GUILayout.Space(10);
		for (int i = 0; i < (PlayerStatus.playerStatus.lives - 1); i++)
			GUILayout.Label(livesIcon);
	}

	public void PlayLife()
	{
		gameObject.SetActive(true);
	}

	public void Pause()
	{
		gameObject.SetActive(false);
	}
}

