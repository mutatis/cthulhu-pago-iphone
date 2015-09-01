using UnityEngine;
using System.Collections;

public class TestIndi : MonoBehaviour
{
	bool ok;
	
	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt("timeS", 0);
	}
	public void muda()
	{
		Time.timeScale = 1;
		StartCoroutine("Go");
	}

	IEnumerator Go()
	{
		AsyncOperation async = Application.LoadLevelAsync("Loading");
		yield return async;
	}
}
