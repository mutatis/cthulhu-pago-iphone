using UnityEngine;
using System.Collections;

public class MultiSpawner : MonoBehaviour
{
    public bool autoStart = true;
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	private bool[] spawnControllers;	
	public Transform[] spawnPoints;		
	public GameObject[] enemies;		// Array of enemy prefabs.
	bool ok;

	private bool isRunningCoroutine;


	IEnumerator Start ()
	{
        yield return new WaitForSeconds(spawnDelay);
        NotificationCenter.DefaultCenter().AddObserver(this, "StartSpawner");
        NotificationCenter.DefaultCenter().AddObserver(this, "StopSpawner");
		spawnControllers = new bool[spawnPoints.Length];
        if (autoStart)
            StartCoroutine("Spawn");
	}

	void Update()
	{
		spawnTime = spawnTime - (0.03f * Time.deltaTime);
		if(spawnTime <= 1f)
		{
			spawnTime = 1f;
		}
	}

	IEnumerator Spawn ()
	{
		isRunningCoroutine = true;

        // Start calling the Spawn function repeatedly after a delay .
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
			FillSpawnControllers ();

			for (int i = 0; i<spawnPoints.Length; i++)
			{
				if (spawnControllers[i])
				{
					int enemyIndex = Random.Range(0, enemies.Length);
					PoolManager.Pools["props"].Spawn(enemies[enemyIndex].transform, spawnPoints[i].position, spawnPoints[i].rotation);
					spawnPoints[i].BroadcastMessage("OnSpawn",enemyIndex);
					// Play the spawning effect from all of the particle systems.
					foreach(ParticleSystem p in spawnPoints[i].GetComponentsInChildren<ParticleSystem>())
					{
						p.Play();
					}
				}
			}
    		
            yield return new WaitForSeconds(spawnTime);
        }

	}

	void FillSpawnControllers ()
	{
		int i;
		bool tester;
		for (i = 0; i<spawnPoints.Length; i++)
		{
			spawnControllers[i] = (Random.value > 0.5f);
		}

		tester = spawnControllers [0];

		for (i = 0; i<spawnControllers.Length; i++)
		{
			if (tester != spawnControllers[i])
				return;
		}

		FillSpawnControllers ();
	}

    void StartSpawner (int spawnTime)
    {
        Random.seed ++;
		spawnTime = spawnTime;

		if (!isRunningCoroutine)
        	StartCoroutine("Spawn");
    }

    void StopSpawner ()
    {
        StopCoroutine("Spawn");
		isRunningCoroutine = false;
    }
}