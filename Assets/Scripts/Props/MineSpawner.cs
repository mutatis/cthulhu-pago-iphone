using UnityEngine;
using System.Collections;

public class MineSpawner : MonoBehaviour
{
    public bool autoStart = true;
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
    public int minSpawnTime = 1;
    public int maxSpawnTime = 8;
    public int minSpawnDelay = 2;
    public int maxSpawnDelay = 6;
	public Animator rosto;
	int ran;
	bool ok;

	private bool isRunningCoroutine;


	IEnumerator Start ()
	{
        yield return new WaitForSeconds(spawnDelay);
        NotificationCenter.DefaultCenter().AddObserver(this, "StartSpawner");
        NotificationCenter.DefaultCenter().AddObserver(this, "StopSpawner");

        if (autoStart)
            StartCoroutine("Spawn");
	}

	void Update()
	{
		if(PlayerPrefs.GetInt("dificuldade") == 1 && ok == false)
		{
			spawnDelay = spawnDelay*2;
			spawnTime = spawnTime*2;
			maxSpawnDelay = maxSpawnDelay*2;
			minSpawnDelay = minSpawnDelay*2;
			maxSpawnTime = maxSpawnTime*2;
			minSpawnTime = minSpawnTime*2;
			ok = true;
		}
	}

    IEnumerator Spawn ()
	{
		isRunningCoroutine = true;

        // Start calling the Spawn function repeatedly after a delay .
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
    		// Instantiate a random enemy.
    		int enemyIndex = Random.Range(0, enemies.Length);
			ran = Random.Range(0, 3);
			if(ran == 2 && rosto != null && PlayerStatus.playerStatus.rigidbody2D.velocity.y >= 0)
			{
				StartCoroutine("Susto");
			}
            PoolManager.Pools["props"].Spawn(enemies[enemyIndex].transform, transform.position, transform.rotation);
    		// Play the spawning effect from all of the particle systems.
    		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
    		{
    			p.Play();
    		}
            yield return new WaitForSeconds(spawnTime);
        }

	}
	IEnumerator Susto()
	{
		yield return new WaitForSeconds(0.5f);
		rosto.SetTrigger("Susto");
	}

    void StopSpawner ()
    {
        Random.seed ++;
        spawnTime = Random.Range(minSpawnTime,maxSpawnTime);
        spawnDelay = Random.Range(minSpawnDelay,maxSpawnDelay);

		if (!isRunningCoroutine)
        	StartCoroutine("Spawn");
    }

    void StartSpawner ()
    {
        StopCoroutine("Spawn");
		isRunningCoroutine = false;
    }

}