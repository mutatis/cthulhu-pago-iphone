//  GameManager.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       18-12-2013 
using UnityEngine;
using System.Collections;
using SIS;

/// <summary>
/// Game manager class manages GameFlow and GameInfos beetween different levels.
/// </summary>
/// <remarks>
/// Game manager class tracks playerScores and provite informations cross scenes. It also notifies OnPause, OnResume, OnNewRecord.
/// </remarks>
public class GameManager : MonoBehaviour
{
	public static int coins;
	public int sCoins;
	public int lvlUpCallsInTheLastMission;
	public bool permanentDoubleCoin = false;
	public bool permanentTrippleCoin = false;
	public bool doubleCoin = false;
	public int extraLife = 0;
	public bool hasContinue = false;
	public bool hasRio = false;
	public bool hasChina = false;
	public bool hasSCthulhu = false;
	public bool hasIndi = false;
	public bool hasDagon = false;
	public bool hasFlappy = false;
	public bool hasMoon = false;
	public bool hasAfrica = false;
	public bool hasNewYork = false;
	public bool hasIce = false;
	public bool hasEgypt = false;
	public bool selectRio = false;
	public Interscene transition;
	private static GameManager s_gameManager;//Game Manager singleton variable.
	private bool canLoad = false;
	bool pause;
	public static float totalCoins = 0;
	int time = 0;
	public GameObject sair;
	public string fases = " ";
	public float playerHighScore;//Player Highest Score ever is recorded here
	public float accumulatedScore = 0;//The accumulated score stores your score until this scene.
	public float playerCurrentScore;//accumulatedScore plus current scene score
	public int lastScene;
	AsyncOperation myAsync;//We do an Async load from scene to scene.
	public int gift = 9;
	public int kkk;
	public float moeda;
	public ArrayList to = new ArrayList(); 
	
	/// <summary>
	/// Game Manager Singleton.
	/// </summary>
	/// <value>The game manager.</value>
	public static GameManager gameManager
	{
		get
		{
			if (s_gameManager == null)
			{
				s_gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
				
				if (s_gameManager == null)
				{
					GameObject obj = new GameObject("GameManager");
					s_gameManager = obj.AddComponent(typeof(GameManager)) as GameManager;
				}
			}
			
			return s_gameManager;
		}
	}
	/// <summary>
	/// On Awake this instance is not destroyed.
	/// </summary>
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	int oi;
	public void Remove()
	{
		
		if(to.Count > oi)
		{
			to.RemoveAt(oi);
			oi++;
			Remove();
		}
	}
	
	/// <summary>
	/// We load our Record here. The Game Manager also listens to a OnDead call.
	/// </summary>
	public void Start()
	{
		PlayerPrefs.SetInt ("BuyGame", 1);
		//DBManager.IncreaseFunds("coins", 999999);
		if(PlayerPrefs.GetInt("primeiro") == 0)
		{
			DBManager.IncreaseFunds("coins", -2000);
			PlayerPrefs.SetInt("primeiro", 1);
		}
		to.Add(new Vector3(18.2706f, -34.92065f, -16.03186f));
		moeda = PlayerPrefs.GetFloat("moeda");
		totalCoins = DBManager.GetFunds("coins");
		NotificationCenter.DefaultCenter().AddObserver(this, "OnDead");
		
		if(extraLife > 5)
		{
			extraLife = 5;
			PlayerPrefs.SetInt("extraLife", extraLife);
		}
		
		if (PlayerPrefs.HasKey("Player Score"))
			playerHighScore = PlayerPrefs.GetFloat("Player Score");
		else
			playerHighScore = 0;

		if(PlayerPrefs.GetInt("PermanentTrippleCoin") == 1)
		{
			permanentTrippleCoin = true;
		}
		
		if(PlayerPrefs.GetInt("PermanentDoubleCoin") == 1)
		{
			permanentDoubleCoin = true;
		}
	}
	
	public void Save ()
	{
		moeda = PlayerPrefs.GetFloat("moeda");
		totalCoins = DBManager.GetFunds("coins");
		PlayerPrefs.SetFloat("Player Score",coins);
		PlayerPrefs.SetFloat("moeda", moeda);
		PlayerPrefs.SetFloat("salvaCoins", totalCoins);
		if (permanentDoubleCoin)
			PlayerPrefs.SetInt("PermanentDoubleCoin", 1);
		if (permanentTrippleCoin)
			PlayerPrefs.SetInt("PermanentTrippleCoin", 1);
		if (doubleCoin)
			PlayerPrefs.SetInt("doubleCoin", 1);
		if (extraLife != 0)
			PlayerPrefs.SetInt("extraLife", extraLife);
		if (hasContinue)
			PlayerPrefs.SetInt("hasContinue", 1);
		if (hasRio)
			PlayerPrefs.SetInt("hasRio", 1);
		if (hasMoon)
			PlayerPrefs.SetInt("hasMoon", 1);
		if (hasAfrica)
			PlayerPrefs.SetInt("hasAfrica", 1);
		if (hasEgypt)
			PlayerPrefs.SetInt("hasEgypt", 1);
		if (hasChina)
			PlayerPrefs.SetInt("hasChina", 1);
		if (hasSCthulhu)
			PlayerPrefs.SetInt("hasSCthulhu", 1);
		if (hasIndi)
			PlayerPrefs.SetInt("hasIndi", 1);
		if (hasDagon)
			PlayerPrefs.SetInt("hasDagon", 1);
		if (hasFlappy)
			PlayerPrefs.SetInt("hasFlappy", 1);
		if (hasIce)
			PlayerPrefs.SetInt("hasIce", 1);
		if (hasNewYork)
			PlayerPrefs.SetInt("hasNewYork", 1);
		
		PlayerPrefs.Save();
	}
	/// <summary>
	/// This Update function waits for player input to Pause or Quit
	/// </summary>
	public void Update()
	{
		totalCoins = DBManager.GetFunds("coins");
		//pause = GameObject.FindGameObjectWithTag("Pause").GetComponent<ButtonPause>().pause;
		PlayerPrefs.SetFloat("salvaCoins", totalCoins);
		PlayerPrefs.SetFloat("moeda", moeda);
		if(DBManager.GetFunds("coins") >= 790 && PlayerPrefs.GetInt("Srepelente") != 1)
		{
			PlayerPrefs.SetInt("repelenteN", 10);
		}
		
		if(coins >= 0)
		{
			sCoins = coins;
		}
		
	}
	/// <summary>
	/// Raises the dead event. Here we update or score values.
	/// </summary>
	public void OnDead()
	{
		Time.timeScale = 0;
		playerCurrentScore = accumulatedScore + PlayerStatus.playerStatus.transform.position.x;
		if (playerCurrentScore > playerHighScore)
		{
			NotificationCenter.DefaultCenter().PostNotification(this, "OnNewRecord");
			playerHighScore = playerCurrentScore;
			PlayerPrefs.SetFloat("Player Score", playerCurrentScore);
		}
	}
	
	public void RemoveCoin ()
	{
		RemoveCoin (1);
	}
	
	public void RemoveCoin (int amount)
	{
		coins -= amount;
		if (coins < 0)
			coins = 0;
		totalCoins -= amount;
		if (totalCoins < 0)
			totalCoins = 0;
		DBManager.IncreaseFunds ("coins", (amount * -1));
		if (DBManager.GetFunds ("coins") < 0)
			DBManager.IncreaseFunds ("coins", (DBManager.GetFunds ("coins") * -1));
	}
	public void ResetCoins ()
	{
		//sCoins = coins;
		coins = 0;
	}
	public void AddCoin ()
	{
		AddCoin (1);
	}
	
	public void AddCoin (int amount)
	{
		coins += amount;
		totalCoins += amount;
		moeda += amount;
		DBManager.IncreaseFunds ("coins", amount);
		PlayerPrefs.SetFloat("moeda", moeda);
	}
	
	public void Gift ()
	{
		kkk = 1;
		int random = Random.Range(0, 2);
		if(random == 1)
		{
			gift = 1;
		}
		else
		{
			gift = 0;
		}
	}
	
	public void LoadNextLevel()
	{
		LoadNextLevel (Application.loadedLevel + 1);
	}
	
	
	/// <summary>
	/// Loads the next level.
	/// </summary>
	/// <param name="level">Level.</param>
	public void LoadNextLevel(int level)
	{
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		
		if (level == Application.loadedLevel)
		{
			Application.LoadLevel(level);
			return;
		}
		
		StartCoroutine("LoadingNextLevel", level);
	}
	
	
	public void LoadNextLevel(string level)
	{
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		
		if (level == Application.loadedLevelName)
		{
			Application.LoadLevel(level);
			return;
		}
		
		StartCoroutine("LoadingNextLevel", level);
	}
	
	
	/// <summary>
	/// Loads the next level.
	/// </summary>
	private IEnumerator LoadingNextLevel(int level)
	{
		transition.TransitionIn();
		/*myAsync = Application.LoadLevelAsync(level);
        myAsync.allowSceneActivation = false;
        while (myAsync.progress < 0.89)
        {
            yield return null;
        }

        lastScene = Application.loadedLevel;
        myAsync.allowSceneActivation = true;*/
		
		lastScene = Application.loadedLevel;
		Application.LoadLevel(level);
		yield return 0;
		transition.TransitionOut();
	}
	
	/// <summary>
	/// Loads the next level.
	/// </summary>
	private IEnumerator LoadingNextLevel(string level)
	{
		transition.TransitionIn();
		/*myAsync = Application.LoadLevelAsync(level);
        myAsync.allowSceneActivation = false;
        while (myAsync.progress < 0.89)
        {
            yield return null;
        }
        myAsync.allowSceneActivation = true;
        myAsync = null;*/
		lastScene = Application.loadedLevel;
		
		Application.LoadLevel(level);
		yield return 0;
		transition.TransitionOut();
	}
	
	private void OnApplicationQuit ()
	{
		Save ();
	}
	
	private void OnApplicationPause ()
	{
		Save();
	}
	
	public static bool Buy (int value)
	{
		if (value > totalCoins)
			return false;
		totalCoins -= value;
		DBManager.IncreaseFunds ("coins", (value * -1));
		return true;
	}
}