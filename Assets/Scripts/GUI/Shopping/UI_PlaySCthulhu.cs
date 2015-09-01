using UnityEngine;
using System.Collections;

public class UI_PlaySCthulhu : MonoBehaviour {

	public GameObject canvas;

	public void SCthulhuPlay()
	{
		StartCoroutine("Go");
	}
	IEnumerator Go() 
	{
		canvas.SetActive(false);
		AsyncOperation async = Application.LoadLevelAsync("ManOfSteel");
		yield return async;
	}
}
