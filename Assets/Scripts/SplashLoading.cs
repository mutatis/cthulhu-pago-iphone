using UnityEngine;
using System.Collections;

public class SplashLoading : MonoBehaviour 
{
	public string level;
	bool ok;
	public float tempo;

	// Use this for initialization
	void Start () 
	{
		level = PlayerPrefs.GetString ("level");
		if(level == "")
		{
			level = "Ocean";
		}
		Time.timeScale = 1;
		PlayerPrefs.SetInt("timeS", 0);
		StartCoroutine("Go");
	}
	void Update()
	{
		if(ok)
		{
			Application.LoadLevel(level);
		}
	//	StartCoroutine("Go");
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds(tempo);
		//Application.LoadLevel(level);
		AsyncOperation async = Application.LoadLevelAsync(level);
		if (Application.isLoadingLevel) 
		{    
			Debug.Log ("Loading complete");
			yield return async;
		}
	}
}