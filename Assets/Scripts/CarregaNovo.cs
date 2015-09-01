using UnityEngine;
using System.Collections;

public class CarregaNovo : MonoBehaviour {
	public GameObject loading;
	public GameObject loadingA;
	public GameObject loadingRJ;
	public GameObject loadingARJ;
	public GameObject loadingAF;
	public GameObject loadingAAF;
	public GameObject loadingEG;
	public GameObject loadingAEG;
	public GameObject loadingMO;
	public GameObject loadingAMO;
	public GameObject loadingIC;
	public GameObject loadingAIC;
	public GameObject loadingCH;
	public GameObject loadingACH;
	public GameObject loadingOC;
	public GameObject loadingAOC;
	public GameObject canvas;
	public GameObject canvas1;
	public int type;
	public string level;
	int time = 0;
	// Use this for initialization
	void Start () 
	{
		if(level == "")
		{
			level = "NewYork";
		}
		Screen.orientation = ScreenOrientation.LandscapeRight;

		if(PlayerPrefs.GetString("level") == "NewYork")
		{
			loading.SetActive(true);
			loadingA.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Rio de Janeiro")
		{
			loadingRJ.SetActive(true);
			loadingARJ.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Africa")
		{
			loadingAF.SetActive(true);
			loadingAAF.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Egypt")
		{
			loadingEG.SetActive(true);
			loadingAEG.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Lua")
		{
			loadingMO.SetActive(true);
			loadingAMO.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Ice")
		{
			loadingIC.SetActive(true);
			loadingAIC.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "China")
		{
			loadingCH.SetActive(true);
			loadingACH.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		else
		{
			loadingOC.SetActive(true);
			loadingAOC.SetActive(true);
			canvas.SetActive(false);
			StartCoroutine("Go");
		}
		PlayerPrefs.SetInt("timeS", time);
	}


	IEnumerator Go() 
	{
		if(type == 1)
		{
			canvas1.SetActive(false);
		}
		canvas.SetActive(false);
		AsyncOperation async = Application.LoadLevelAsync(PlayerPrefs.GetString("level"));
		yield return async;
	}
}
