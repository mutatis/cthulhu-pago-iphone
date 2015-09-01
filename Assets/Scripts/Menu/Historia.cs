using UnityEngine;
using System.Collections;

public class Historia : MonoBehaviour
{
	void Start()
	{
		PlayerPrefs.SetString("level", Application.loadedLevelName);
	}
	public void HistoriaGo()
	{
		Application.LoadLevel("Historia");
	}

	public void Some()
	{
		gameObject.SetActive(false);
	}
}