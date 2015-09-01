using UnityEngine;
using System.Collections;

public class carregando : MonoBehaviour 
{
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
	public int type;
	public string level;
	int time = 0;

	void Start()
	{
		if(level == "")
		{
			level = "NewYork";
		}
		Screen.orientation = ScreenOrientation.LandscapeRight;
		if (ShoppingManager.shoppingManager.displayingOption)
			NotificationCenter.DefaultCenter().PostNotification(this,"DisplayNoOptions");
		else if(PlayerPrefs.GetString("level") == "NewYork")
		{
			loading.SetActive(true);
			loadingA.SetActive(true);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Rio de Janeiro")
		{
			loadingRJ.SetActive(true);
			loadingARJ.SetActive(true);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Africa")
		{
			loadingAF.SetActive(true);
			loadingAAF.SetActive(true);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Egypt")
		{
			loadingEG.SetActive(true);
			loadingAEG.SetActive(true);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Lua")
		{
			loadingMO.SetActive(true);
			loadingAMO.SetActive(true);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "Ice")
		{
			loadingIC.SetActive(true);
			loadingAIC.SetActive(true);
			StartCoroutine("Go");
		}
		else if(PlayerPrefs.GetString("level") == "China")
		{
			loadingCH.SetActive(true);
			loadingACH.SetActive(true);
			StartCoroutine("Go");
		}
		else
		{
			loadingOC.SetActive(true);
			loadingAOC.SetActive(true);
			StartCoroutine("Go");
		}
		PlayerPrefs.SetInt("timeS", time);
	}
	IEnumerator Go() 
	{
		AsyncOperation async = Application.LoadLevelAsync(PlayerPrefs.GetString("level"));
		yield return async;
	}
}