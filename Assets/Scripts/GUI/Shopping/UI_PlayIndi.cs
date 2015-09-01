using UnityEngine;
using System.Collections;

public class UI_PlayIndi : MonoBehaviour {

	public GameObject canvas;
	
	public void IndiPlay()
	{
		canvas.SetActive(false);
		Application.LoadLevel("Indi");
	}
}
