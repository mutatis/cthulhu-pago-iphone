using UnityEngine;
using System.Collections;

public class UI_PlayFlappy : MonoBehaviour 
{
	public GameObject canvas;
	
	public void FlappyPlay()
	{
		StartCoroutine("Go");
	}
	IEnumerator Go() 
	{
		canvas.SetActive(false);
		AsyncOperation async = Application.LoadLevelAsync("FlappyCthulhu");
		yield return async;
	}
}
