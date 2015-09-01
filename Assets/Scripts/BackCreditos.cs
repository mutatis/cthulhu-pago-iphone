using UnityEngine;
using System.Collections;

public class BackCreditos : MonoBehaviour 
{
	public SpriteRenderer loading;
	int time = 0;

	public void Load () 
	{
		PlayerPrefs.SetInt("timeS", time);
		loading.enabled = true;
		renderer.enabled = true;
		StartCoroutine("Go");
	}

	IEnumerator Go() 
	{
		AsyncOperation async = Application.LoadLevelAsync("NewYork");
		yield return async;
		Debug.Log(async.progress);
		if(!async.isDone)
		{
			Debug.Log(async.progress);
			yield return 0;
		}
	}
}
