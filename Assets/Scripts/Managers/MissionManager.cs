//  MissionManager.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       18-12-2013 
using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Mission manager manages your current scene.
/// </summary>
/// <remarks>
/// Mission manager says the limit and do major difficult adjustment.
/// </remarks>
public class MissionManager : MonoBehaviour
{
	private static MissionManager s_missionManager;//Singleton
	public static MissionManager mission;
	public float limit = 1000;//limit of new york scene
    public float onLvlUp = 1000;
    public bool haveItems;
    private int callNumber = 0;
	public string level;
	public GameObject loading;
	public GameObject loadingA;
	public GameObject pause;
	public GameObject coins;
	public GameObject distancia;
	public GameObject life;
	public GameObject block;
	public GameObject music;
	public GameObject[] desativar;

	public static MissionManager missionManager
	{
		get
		{
			if (s_missionManager == null)
			{
				s_missionManager =  FindObjectOfType(typeof (MissionManager)) as MissionManager;
				
				if (s_missionManager == null)
				{
					GameObject obj = new GameObject("MissionManager");
					s_missionManager = obj.AddComponent(typeof (MissionManager)) as MissionManager;
				}
			}
			
			return s_missionManager;
		}
	}

	void Awake()
	{
		mission = this;
	}

   /// <summary>
   /// Update this instance.
   /// </summary>
	void Start ()
	{
        if (haveItems)
            PowerUpBehaviour.SpawnNewItem();
        StartCoroutine("OnMissionUpdate");
    }

	void Update()
	{
		if (PlayerStatus.playerStatus.transform.position.x >= limit) 
		{

		}
	}

    /// <summary>
    /// Raises the new york update event.
    /// </summary>
    IEnumerator OnMissionUpdate ()
	{
        while (PlayerStatus.playerStatus.transform.position.x < limit)
        {
            if (PlayerStatus.playerStatus.transform.position.x > onLvlUp)
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "OnLvlUp", callNumber);
                callNumber ++;
                onLvlUp += onLvlUp;
            }
            yield return null;
        }
		for (int i = 0; i < desativar.Length; i++)
		{
			desativar[i].SetActive(false);
		}
		NotificationCenter.DefaultCenter().PostNotification(this, "QuitScene");
		GameManager.gameManager.lvlUpCallsInTheLastMission = callNumber;
		block.SetActive(false);
		PlayerPrefs.SetInt("timeS", 1);
        yield return new WaitForSeconds(8);
		pause.SetActive(false);
		coins.SetActive(false);
		loading.SetActive(false);
		distancia.SetActive(false);
		life.SetActive(false);
		loading.SetActive(true);
		loadingA.SetActive(true);
		PlayerPrefs.SetInt("timeS", 1);
		Destroy(music.gameObject);
		AsyncOperation async = Application.LoadLevelAsync(level);
		yield return async;
		PlayerPrefs.SetInt("timeS", 1);
        StopCoroutine("OnMissionUpdate");
    }
}